using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class CompletedJobOfferDto
    {
        public string Id { get; set; }

        public JobOfferDto JobOffer { get; set; }

        public CompletionResultDto Result { get; set; }
    }
}
