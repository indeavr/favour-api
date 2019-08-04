using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class SavedJobOfferDto
    {
        public string ConsumerId { get; set; }

        public ConsumerDto Consumer { get; set; }

        public string JobOfferId { get; set; }

        public JobOfferDto JobOffer { get; set; }
    }
}
