using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using FavourAPI.Data.Models.Enums;
using FavourAPI.Data;

namespace FavourAPI.Services
{
    public class OfferService : IOfferService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public OfferService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddJobOffer(string userId, JobOfferDto jobOfferDto)
        {
            var jobOffer = mapper.Map<JobOffer>(jobOfferDto);
            Guid guidUserId = Guid.Parse(userId);
            var provider = dbContext.CompanyProviders.SingleOrDefault(u => u.Id == guidUserId);
            var state = dbContext.JobOfferStates.SingleOrDefault(jos => jos.Value == nameof(JobOfferState.Available));

            jobOffer.State = state;

            provider.Offers.Add(jobOffer);

            // TODO: review may be redundant
            this.dbContext.JobOffers.Add(jobOffer);
            this.dbContext.SaveChanges();
        }

        public void AddApplication(string consumerId, string jobOfferId, ApplicationDto applicationDto)
        {
            var application = mapper.Map<Application>(applicationDto);

            Guid guidUserId = Guid.Parse(consumerId);
            Guid guidJobOfferId = Guid.Parse(jobOfferId);

            var consumer = this.dbContext.Consumers.SingleOrDefault(c => c.Id == guidUserId);
            var jobOffer = this.dbContext.JobOffers.SingleOrDefault(job => job.Id == guidJobOfferId);

            application.Consumer = consumer;
            application.State = new ApplicationStateDb()
            {
                Value = nameof(ApplicationState.Pending)
            };

            jobOffer.Applications.Add(application);

            this.dbContext.SaveChanges();
        }

        public List<JobOfferDto> GetAllOffers()
        {
            var offers = dbContext.JobOffers.ToList();

            // mahni neshta ot job modela- . inache se polzva samo DTO-to 

            return offers.Select(o => mapper.Map<JobOfferDto>(o)).ToList();
        }
    }
}
