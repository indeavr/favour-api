using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class ProviderOngoingOfferDto
    {
        public ConsumerDto[] Consumers { get; set; }

        public JobOfferDto JobOffer { get; set; }

        public bool IsDeleted { get; set; }
    }
}
