﻿using FavourAPI.Models.enums;

namespace FavourAPI.Services
{
    internal class JobOfferStateDbnameof : JobOfferStateDb
    {
        private JobOfferState available;

        public JobOfferStateDbnameof(JobOfferState available)
        {
            this.available = available;
        }
    }
}