using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class OfficeDto
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public EmailDto[] Emails { get; set; }

        public PhoneNumberDto[] PhoneNumbers { get; set; }

        public IndustryDto[] Industries { get; set; }
    }
}
