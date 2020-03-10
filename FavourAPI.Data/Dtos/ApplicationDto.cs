﻿using System;

namespace FavourAPI.Dtos
{
    public class ApplicationDto
    {
        public string Id { get; set; }

        public DateTime Time { get; set; }

        public string Message { get; set; }

        public ProviderDto Provider { get; set; }

        public ActiveJobOfferDto ActiveJobOffer { get; set; }
    }
}
