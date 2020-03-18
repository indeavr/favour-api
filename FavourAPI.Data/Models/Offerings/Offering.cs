using FavourAPI.Data.Models.Offerings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class Offering
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public DateTime TimePosted { get; set; }

        public virtual Provider Provider { get; set; }

        public double Money { get; set; }

        //public virtual ICollection<Skill> Skills { get; set; } 

        public virtual CompletionResult Result { get; set; } // ????

        //public virtual ICollection<SavedJobOffer> SavedJobOffers { get; set; }

        public virtual ICollection<JobPhoto> Photos { get; set; } // ????

        public virtual ActiveOffering ActiveState { get; set; }

        public virtual ICollection<CompletedOffering> CompletedStates { get; set; }

        public virtual ICollection<OngoingOffering> OngoingStates { get; set; }
    }
}
