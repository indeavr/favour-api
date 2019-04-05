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

        public string Location { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }

        public virtual SexDb Sex { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual User User { get; set; }

        public byte[] CV { get; set; }

        public virtual ICollection<CompletionResult> CompletedJobs { get; set; }

        public virtual ICollection<ConsumerJobOffer> ConsumerJobOffers { get; set; }

        //public ICollection<byte[]> Photos { get; set; }
    }
}
