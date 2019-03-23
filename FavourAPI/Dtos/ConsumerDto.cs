using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class ConsumerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SexDb Sex { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<JobOffer> Offers { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public byte[] CV { get; set; }
    }
}
