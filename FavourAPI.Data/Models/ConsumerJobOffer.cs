using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class ConsumerJobOffer
    {
        [Key]
        public Guid ConsumerId { get; set; }

        public virtual Consumer Consumer { get; set; }

        [Key]
        public Guid JobOfferId { get; set; }

        public virtual JobOffer JobOffer { get; set; }
    }
}
