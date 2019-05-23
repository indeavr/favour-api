using System;

namespace FavourAPI.Dtos
{
    public class OfficeDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public EmailDto[] Emails { get; set; }

        public PhoneNumberDto[] PhoneNumbers { get; set; }

        public IndustryDto[] Industries { get; set; }
    }
}
