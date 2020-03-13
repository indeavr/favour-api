using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class OngoingJobOffer
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid ProviderId { get; set; }

        public virtual Provider Provider { get; set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid JobOfferId { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        public bool IsDeleted { get; set; }
    }
}
