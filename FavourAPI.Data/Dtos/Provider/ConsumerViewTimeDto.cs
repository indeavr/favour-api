using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class ConsumerViewTimeDto
    {
        public string Id { get; set; }

        public DateTime Applications { get; set; }

        public DateTime OngoingJobOffers { get; set; }
    }
}
