using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Data.Models;
using FavourAPI.Data.Models.Enums;
using FavourAPI.Dtos;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers.Exceptions;
using FavourAPI.Services.Helpers.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public ApplicationService([FromServices] WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Result<ApplicationDto>> Apply(string userId, string jobOfferId, string message, DateTime time)
        {
            var userIdGuid = Guid.Parse(userId);
            var jobOfferIdGuid = Guid.Parse(jobOfferId);
            var consumer = this.dbContext.Consumers.Single(c => c.Id == userIdGuid);
            var jobOffer = this.dbContext.JobOffers.Single(jo => jo.Id == jobOfferIdGuid);
            var state = this.dbContext.ApplicationStates.Single(a => a.Value == nameof(ApplicationState.Pending));

            var application = new Application()
            {
                State = state,
                Consumer = consumer,
                ActiveJobOffer = jobOffer.ActiveState,
                Message = message,
                Time = time
            };

            this.dbContext.Applications.Add(application);

            await this.dbContext.SaveChangesAsync();

            var dto = this.mapper.Map<ApplicationDto>(application);

            return new OkResult<ApplicationDto>(dto);
        }

        public async Task<Result<object>> Accept(string applicationId)
        {
            var guidId = Guid.Parse(applicationId);
            var application = this.dbContext.Applications.Single(a => a.Id == guidId);

            return await ChangeApplicationState(application, ApplicationState.Accepted);
        }

        public async Task<Result<object>> Reject(string applicationId)
        {
            var guidId = Guid.Parse(applicationId);
            var application = this.dbContext.Applications.Single(a => a.Id == guidId);

            return await ChangeApplicationState(application, ApplicationState.Rejected);
        }

        public async Task<Result<object>> ConfirmJobOffer(string applicationId)
        {
            var guidId = Guid.Parse(applicationId);
            var application = this.dbContext.Applications.Single(a => a.Id == guidId);
            var jobOffer = application.ActiveJobOffer;
            if (jobOffer == null)
            {
                throw new InvalidJobOfferStateException("The confirmed job offer was not active");
            }

            await this.dbContext.OngoingJobOffers.AddAsync(new OngoingJobOffer()
            {
                Consumer = application.Consumer,
                JobOffer = jobOffer.JobOffer,
            });

            await this.dbContext.SaveChangesAsync();

            return new OkResult<object>(null);
        }

        public List<ApplicationDto> Get(string jobOfferId)
        {
            var applicationsForJob = dbContext.ActiveJobOffers.FirstOrDefault(job => job.Id == Guid.Parse(jobOfferId));

            return applicationsForJob.Applications
                .Select(application => this.mapper.Map<ApplicationDto>(application))
                .ToList();
        }

        private async Task<Result<object>> ChangeApplicationState(Application application, ApplicationState newState)
        {
            try
            {
                var newStateDb = this.dbContext.ApplicationStates.Single(aps => aps.Value == newState.ToString());
                application.State = newStateDb;
                this.dbContext.Applications.Update(application);
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new FavourAPI.Services.Helpers.Result.InvalidResult<object>(e.Message);
            }

            return new FavourAPI.Services.Helpers.Result.OkResult<object>(null);
        }
    }
}
