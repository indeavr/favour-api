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
            string name = "123";
            for (int i = 1001; i < 1021; i++)
            {
                provider.Offers.Add(new JobOffer
                {
                    Title = "Waiter" + name + i,
                    Description = "PART TIME: Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Money = i + 100,
                    TimePosted = new DateTime(),
                    Location = "Sofia",
                });
            }
            for (int i = 0; i < 1000; i++)
            {
                provider.Offers.Add(new JobOffer
                {
                    Title = "Nasa Engineer" + name + i,
                    Description = "Nasa Hacker" + name + i,
                    Money = i + 100,
                    TimePosted = new DateTime(),
                    Location = "Sofia",
                });
            }

            // TODO: review may be redundant
            this.dbContext.JobOffers.Add(jobOffer);
            this.dbContext.SaveChanges();
        }

        public void AddApplication(string consumerId, string jobOfferId, ApplicationDto applicationDto)
        {
            var application = mapper.Map<Application>(applicationDto);

            var consumer = this.dbContext.Consumers.SingleOrDefault(c => c.Id == consumerId);
            var jobOffer = this.dbContext.JobOffers.SingleOrDefault(job => job.Id == jobOfferId);

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
