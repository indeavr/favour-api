using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Models;
using FavourAPI.Models.enums;

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
            var provider = dbContext.CompanyProviders.SingleOrDefault(u => u.Id == userId);


            jobOffer.State = new JobOfferStateDb()
            {
                Value = nameof(JobOfferState.Available)
            };

            provider.Offers.Add(jobOffer);
            //string name = "123";
            //for (int i = 0; i < 1000; i++)
            //{
            //    provider.Offers.Add(new JobOffer
            //    {
            //        Title = "Nasa Hacker" + name + i,
            //        Description = "Nasa Hacker" + name + i,
            //        Money = i + 100,
            //        TimePosted = new DateTime(),
            //        Location = "Sofia",
            //    });
            //}

            // TODO: review may be redundant
            this.dbContext.JobOffers.Add(jobOffer);
            this.dbContext.SaveChanges();
        }

        public void AddApplication(string consumerId, string jobOfferId, ApplicationDto applicationDto)
        {
            var application = Mapper.Map<Application>(applicationDto);

            var consumer = this.dbContext.Consumers.SingleOrDefault(c => c.Id == consumerId);
            var jobOffer = this.dbContext.JobOffers.SingleOrDefault(job => job.Id == jobOfferId);

            application.Consumer = consumer;

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
