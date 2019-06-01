using FavourAPI.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class JobOffer
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public double Money { get; set; }
        public string Description { get; set; }
        public DateTime TimePosted { get; set; }

        [ForeignKey("User")]
        public Guid UserProviderId { get; set; }
        public Guid? ResultId { get; set; }
        public string StateValue { get; set; }

        public virtual User Provider { get; set; }
        public virtual CompletionResult Result { get; set; }
        public virtual JobOfferStateDb State { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Skill> RequiredSkills { get; set; }
        public virtual ICollection<ConsumerJobOffer> ConsumerJobOffers { get; set; }
        public virtual ICollection<JobPhoto> Photos { get; set; }
        public virtual ICollection<Period> Periods { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
