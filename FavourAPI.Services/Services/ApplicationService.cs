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

namespace FavourAPI.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public ApplicationService([FromServices] WorkFavourDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Result<object> Apply(string userId, string jobOfferId, string message, DateTime time)
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
                JobOffer = jobOffer,
                Message = message,
                Time = time
            };

            this.dbContext.Applications.Add(application);

            this.dbContext.SaveChanges();

            return new OkResult<object>(null);
        }

        public Result<object> Accept(string applicationId)
        {
            var guidId = Guid.Parse(applicationId);
            var application = this.dbContext.Applications.Single(a => a.Id == guidId);

            return ChangeApplicationState(application, ApplicationState.Accepted);
        }

        public Result<object> Reject(string applicationId)
        {
            var guidId = Guid.Parse(applicationId);
            var application = this.dbContext.Applications.Single(a => a.Id == guidId);

            return ChangeApplicationState(application, ApplicationState.Rejected);
        }

        public Result<object> ConfirmJobOffer(string applicationId)
        {
            var guidId = Guid.Parse(applicationId);
            var jobOffer = this.dbContext.Applications.Single(application => application.Id == guidId).JobOffer;
            if (jobOffer.State.Value != nameof(JobOfferState.Active))
            {
                throw new InvalidJobOfferStateException(jobOffer.State.Value, JobOfferState.Active);
            }
            return ChangeJobOfferState(jobOffer, JobOfferState.Upcoming);
        }

        public List<ApplicationDto> Get(string jobOfferId)
        {
            var applicationsForJob = dbContext.JobOffers.FirstOrDefault(job => job.Id == Guid.Parse(jobOfferId));

            return applicationsForJob.Applications
                .Select(application => this.mapper.Map<ApplicationDto>(application))
                .ToList();
        }

        private Result<object> ChangeJobOfferState(JobOffer jobOffer, JobOfferState newState)
        {
            try
            {
                var newStateDb = this.dbContext.JobOfferStates.Single(jos => jos.Value == nameof(newState));
                jobOffer.State = newStateDb;

                this.dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new FavourAPI.Services.Helpers.Result.InvalidResult<object>(e.Message);
            }

            return new FavourAPI.Services.Helpers.Result.OkResult<object>(null);
        }

        private Result<object> ChangeApplicationState(Application application, ApplicationState newState)
        {
            try
            {
                var newStateDb = this.dbContext.ApplicationStates.Single(aps => aps.Value == nameof(newState));
                application.State = newStateDb;

                this.dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return new FavourAPI.Services.Helpers.Result.InvalidResult<object>(e.Message);
            }

            return new FavourAPI.Services.Helpers.Result.OkResult<object>(null);
        }
    }
}
