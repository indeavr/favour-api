using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class CompletedJobOfferDto
    {
        public string Id { get; set; }

        public JobOfferDto JobOffer { get; set; }

        public List<CompletionResultDto> Result { get; set; }
    }
}
