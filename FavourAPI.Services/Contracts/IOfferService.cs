using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    /** WARNING !!!!!!!!!!!!!!!!!!!!!!!!! DEPRECATED DO NOT USE*/
    public interface IOfferService
    {
        Task<JobOfferDto> AddJobOffer(string Guid, JobOfferDto jobOffer);

        Task<JobOfferDto> GetById(string jobId);

        List<JobOfferDto> GetAllOffers();

        Task AddApplication(string consumerId, string jobOfferId, ApplicationDto application);
    }
}
