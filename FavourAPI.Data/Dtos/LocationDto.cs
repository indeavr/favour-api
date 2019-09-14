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
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
    }
}
