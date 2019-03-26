﻿using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IOfferService
    {
        void AddJobOffer(string userId, JobOfferDto jobOffer);

        List<JobOfferDto> GetAllOffers();
    }
}
