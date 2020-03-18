using FavourAPI.Data.Dtos;
using FavourAPI.Data.Models;
using System.Collections.Generic;

namespace FavourAPI.Dtos
{
    public class PersonConsumerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Sex { get; set; }

        public List<LocationDto> Locations { get; set; }

        public List<ImageDto> Photos { get; set; }

        public List<PhoneNumberDto> PhoneNumbers { get; set; }

        public List<ApplicationDto> Applications { get; set; }

    }
}
