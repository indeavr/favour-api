using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class ActiveJobOfferDto
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public JobOfferDto JobOffer { get; set; }

        public List<ApplicationDto> Applications { get; set; }
    }
}

