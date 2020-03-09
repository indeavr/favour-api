using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Data.Dtos.Favour
{
    public class ActiveFavourDto
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public FavourDto JobOffer { get; set; }

        public List<ApplicationDto> Applications { get; set; }
    }
}
