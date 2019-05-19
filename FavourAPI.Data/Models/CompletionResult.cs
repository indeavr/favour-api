using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class CompletionResult
    {
        [ForeignKey("JobOffer")]
        public string Id { get; set; }

        public virtual Consumer Consumer { get; set; }

        public string Review { get; set; }
    }
}
