using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class LocationDto
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
