using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class SavedJobOffer
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid ConsumerId { get; set; }

        public virtual Provider Consumer { get; set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid JobOfferId { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        // Will be useful
        // public DateTime TimeSaved { get; set; }
    }
}
