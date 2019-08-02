using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class JobOfferSearchResponse
    {
        public List<JobOfferDto> JobOffers { get; set; }

        public int totalJobOffers { get; set; }

        public bool hasMore { get; set; }
    }
}
