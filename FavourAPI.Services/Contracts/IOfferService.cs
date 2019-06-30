﻿using FavourAPI.Dtos;
using System;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public interface IOfferService
    {
        void AddJobOffer(string Guid, JobOfferDto jobOffer);

        List<JobOfferDto> GetAllOffers();

        void AddApplication(string consumerId, string jobOfferId, ApplicationDto application);
    }
}
