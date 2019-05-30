using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class JobPhoto
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public byte[] Photo { get; set; }

        [ForeignKey("JobOffer")]
        public Guid JobOfferId { get; set; }

        public virtual JobOffer JobOffer { get; set; }
    }
}
