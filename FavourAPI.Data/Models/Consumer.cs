using System;
using FavourAPI.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FavourAPI.Data.Models
{
    public class Consumer
    {
        [ForeignKey("User")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Location Location { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }

        public virtual SexDb Sex { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual User User { get; set; }

        public byte[] CV { get; set; }

        public virtual ICollection<CompletionResult> CompletedJobs { get; set; }

        public virtual ICollection<ConsumerJobOffer> OngoingJobOffers { get; set; }

        public virtual ICollection<ConsumerJobOffer> SavedJobOffers { get; set; }

        public virtual Image ProfilePhoto { get; set; }

        //public ICollection<byte[]> Photos { get; set; }
    }
}
