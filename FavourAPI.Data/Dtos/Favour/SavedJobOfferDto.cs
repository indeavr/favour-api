using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class SavedJobOfferDto
    {
        public string ConsumerId { get; set; }

        public ProviderDto Consumer { get; set; }

        public string JobOfferId { get; set; }

        public JobOfferDto JobOffer { get; set; }
    }
}
