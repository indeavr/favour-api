using FavourAPI.Data.Models;
using System.Collections.Generic;

namespace FavourAPI.Dtos
{
    public class ConsumerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public string Sex { get; set; }

        public List<Skill> Skills { get; set; }

        public List<JobOffer> Offers { get; set; }

        //public byte[] CV { get; set; }

        //public List<byte[]> Photos { get; set; }
    }
}
