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

        public string Description { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public virtual ICollection<JobOfferLocation> Locations { get; set; }

        public DateTime TimePosted { get; set; }

        public virtual CompanyConsumer CompanyConsumer { get; set; }

        public double Money { get; set; }

        public virtual ICollection<Skill> RequiredSkills { get; set; }

        public virtual CompletionResult Result { get; set; }

        public virtual ICollection<SavedJobOffer> SavedJobOffers { get; set; }

        public virtual ICollection<JobPhoto> Photos { get; set; }

        public virtual ActiveJobOffer ActiveState { get; set; }

        public virtual CompletedJobOffer CompletedState { get; set; }

        public virtual ICollection<OngoingJobOffer> OngoingState { get; set; }
    }
}
