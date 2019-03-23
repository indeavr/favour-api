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

        public void AddJobOffer(JobOfferDto jobOffer)
        {
            var dbOffer = mapper.Map<JobOffer>(jobOffer);

            this.dbContext.JobOffers.Add(dbOffer);
            this.dbContext.SaveChanges();
        }
    }
}
