using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class JobPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("JobOffer")]
        public string JobOfferId { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        public byte[] Photo { get; set; }
    }
}
