using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class Consumer
    {
        [ForeignKey("User")]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public SexDb Sex { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<JobOffer> Offers { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public virtual User User { get; set; }

        public byte[] CV { get; set; }
    }
}
