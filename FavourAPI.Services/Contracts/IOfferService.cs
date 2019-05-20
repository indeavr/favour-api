using FavourAPI.Dtos;
using System;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public interface IOfferService
    {
        void AddJobOffer(Guid Guid, JobOfferDto jobOffer);

        List<JobOfferDto> GetAllOffers();

        void AddApplication(Guid consumerId, Guid jobOfferId, ApplicationDto application);
    }
}
