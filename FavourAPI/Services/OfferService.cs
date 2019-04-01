using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Models;

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

        public void AddJobOffer(string userId, JobOfferDto jobOffer)
        {
            var dbOffer = mapper.Map<JobOffer>(jobOffer);
            var provider = dbContext.CompanyProviders.SingleOrDefault(u => u.Id == userId);

            provider.Offers.Add(dbOffer);
            string name = "123";
            for (int i = 0; i < 1000; i++)
            {
                provider.Offers.Add(new JobOffer
                {
                    Title = "Nasa Hacker" + name + i,
                    Description = "Nasa Hacker" + name + i,
                    Money = i + 100,
                    TimePosted = new DateTime(),
                    Location = "Sofia",
                });
            }

            this.dbContext.JobOffers.Add(dbOffer);
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
