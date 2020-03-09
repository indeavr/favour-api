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

        public string Town { get; set; }

        // Neighborhood/Province/Region
        public string Region { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string CustomInfo { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
