using System;
using System.ComponentModel.DataAnnotations;

namespace FavourAPI.Data.Models
{
    public class JobOfferLocation
    {
        [Key]
        public Guid JobOfferId { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        [Key]
        public Guid LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
