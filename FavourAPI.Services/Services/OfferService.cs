using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using FavourAPI.Data.Models.Enums;
using FavourAPI.Data;
using System.Threading.Tasks;

namespace FavourAPI.Services
{

    /** WARNING !!!!!!!!!!!!!!!!!!!!!!!!! DEPRECATED DO NOT USE*/
    public class OfferService : IOfferService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public OfferService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }    /** WARNING !!!!!!!!!!!!!!!!!!!!!!!!! DEPRECATED DO NOT USE*/

        public async Task<JobOfferDto> AddJobOffer(string userId, JobOfferDto jobOfferDto)
        {
            // Job Offer State is Ignored
            var jobOffer = mapper.Map<JobOffer>(jobOfferDto);
            Guid guidUserId = Guid.Parse(userId);
            var position = dbContext.Positions.SingleOrDefault(p => p.Name == jobOfferDto.Title);

            var provider = dbContext.CompanyConsumers.SingleOrDefault(u => u.Id == guidUserId);

            jobOffer.Title = position.Name;
            provider.Offers.Add(jobOffer);

            // TODO: review may be redundant
            this.dbContext.JobOffers.Add(jobOffer);

            await this.dbContext.SaveChangesAsync();

            await this.dbContext.ActiveJobOffers.AddAsync(new ActiveJobOffer()
            {
                JobOffer = jobOffer,
                Id = jobOffer.Id,
                Applications = new List<Application>()
            });

            await this.dbContext.SaveChangesAsync();

            return this.mapper.Map<JobOfferDto>(jobOffer);
            /** WARNING !!!!!!!!!!!!!!!!!!!!!!!!! DEPRECATED DO NOT USE*/
        }

        public async Task AddApplication(string consumerId, string jobOfferId, ApplicationDto applicationDto)
        {
            var application = mapper.Map<Application>(applicationDto);

            Guid guidUserId = Guid.Parse(consumerId);
            Guid guidJobOfferId = Guid.Parse(jobOfferId);

            var consumer = this.dbContext.PersonConsumers.SingleOrDefault(c => c.Id == guidUserId);
            var jobOffer = this.dbContext.ActiveJobOffers.SingleOrDefault(job => job.Id == guidJobOfferId);

            application.PersonConsumer = consumer;
            application.State = new ApplicationStateDb()
            {
                Value = nameof(ApplicationState.Pending)
            };

            jobOffer.Applications.Add(application);

            await this.dbContext.SaveChangesAsync();
        }

        public List<JobOfferDto> GetAllOffers()
        {
            var offers = dbContext.JobOffers.ToList();

            // mahni neshta ot job modela- . inache se polzva samo DTO-to 

            return offers.Select(o => mapper.Map<JobOfferDto>(o)).ToList();
        }
        /** WARNING !!!!!!!!!!!!!!!!!!!!!!!!! DEPRECATED DO NOT USE*/

        public async Task<JobOfferDto> GetById(string jobId)
        {
            var idAsGuid = Guid.Parse(jobId);
            var jobOfferDb = await this.dbContext.JobOffers.FindAsync(jobId);

            return this.mapper.Map<JobOfferDto>(jobOfferDb);
        }
    }
}
