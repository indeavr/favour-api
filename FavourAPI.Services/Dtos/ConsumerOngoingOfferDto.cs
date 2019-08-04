using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class ConsumerOngoingOfferDto
    {
        public JobOfferDto JobOffer { get; set; }

        public bool IsDeleted { get; set; }
    }
}
