using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class JobOfferLocation
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid JobOfferId { get; set; }
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid LocationId { get; set; }

        public virtual JobOffer JobOffer { get; set; }
        public virtual Location Location { get; set; }
    }
}
