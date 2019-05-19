using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IOfferService
    {
        void AddJobOffer(string userId, JobOfferDto jobOffer);

        List<JobOfferDto> GetAllOffers();

        void AddApplication(string consumerId, string jobOfferId, ApplicationDto application);
    }
}
