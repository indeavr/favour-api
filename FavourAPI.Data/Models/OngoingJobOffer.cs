using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class OngoingJobOffer
    {
        [ForeignKey("JobOffer")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        public virtual ConsumerDto Consumer { get; set; }
    }
}
