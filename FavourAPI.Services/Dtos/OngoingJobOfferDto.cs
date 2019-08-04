using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class OngoingJobOfferDto
    {
        public string Id { get; set; }

        public JobOfferDto JobOffer { get; set; }

        public ConsumerDto Consumer { get; set; }
    }
}
