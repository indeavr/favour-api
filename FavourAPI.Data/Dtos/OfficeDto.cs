using FavourAPI.Dtos;
using System;

namespace FavourAPI.Dtos
{
    public class OfficeDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public LocationDto Location { get; set; }

        public EmailDto[] Emails { get; set; }

        public PhoneNumberDto[] PhoneNumbers { get; set; }

        public IndustryDto[] Industries { get; set; }
    }
}
