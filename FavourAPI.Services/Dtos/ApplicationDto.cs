﻿using System;

namespace FavourAPI.Dtos
{
    public class ApplicationDto
    {
        public string Id { get; set; }

        public string State { get; set; }

        public DateTime Time { get; set; }

        public string Message { get; set; }

        public ConsumerDto Consumer { get; set; }

        public JobOfferDto JobOffer { get; set; }
    }
}
