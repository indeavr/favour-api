using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class ConsumerJobOffer
    {
        public string ConsumerId { get; set; }
        public virtual Consumer Consumer { get; set; }

        public string JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
