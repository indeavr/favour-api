using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class ProviderViewTimeDto
    {
        public string Id { get; set; }

        public DateTime Applications { get; set; }

        public DateTime OngoingJobOffers { get; set; }
    }
}
