using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class Location
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string Country { get; set; }

        // Town/City
        public string Area { get; set; }

        // Neighborhood/Province/Region
        public string Region { get; set; }

        public string StreetAddress { get; set; }

        public string ZipCode { get; set; }

        public string CustomInfo { get; set; }

        // TODO: are this two for here?
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
