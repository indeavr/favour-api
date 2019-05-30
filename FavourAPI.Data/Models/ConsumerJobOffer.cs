using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class ConsumerJobOffer
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid ConsumerId { get; set; }
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid JobOfferId { get; set; }

        public virtual Consumer Consumer { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
