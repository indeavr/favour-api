using System;
using FavourAPI.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FavourAPI.Data.Models;
using FavourAPI.Data.Models.Offerings;

namespace FavourAPI.Data.Models
{
    public class Provider
    {
        [ForeignKey("User")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual Location Location { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }

        public virtual SexDb Sex { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Position> DesiredPositions { get; set; }

        public virtual ICollection<Application> Applications { get; set; } // for favours

        public virtual ICollection<ActiveOffering> ActiveOfferings { get; set; }

        public virtual ICollection<OngoingOffering> OngoingOfferings { get; set; }

        public virtual ICollection<CompletedOffering> CompletedOfferings { get; set; }
        public virtual User User { get; set; }

        public byte[] CV { get; set; }

        public virtual ICollection<Image> Photos { get; set; }

        //public virtual ICollection<SavedJobOffer> SavedJobOffers { get; set; }

        //public virtual ICollection<Experience> Experiences { get; set; }

        //public virtual ICollection<Education> Education { get; set; }


    }
}
