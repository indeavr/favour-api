using FavourAPI.Data.Dtos.Favour;
using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Data.Dtos.Offerings
{
    public class ActiveOfferingDto
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public OfferingDto Offering { get; set; }

        public List<ApplicationDto> Applications { get; set; }
    }
}
