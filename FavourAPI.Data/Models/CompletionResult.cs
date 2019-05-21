using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class CompletionResult
    {
        [ForeignKey("JobOffer")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual Consumer Consumer { get; set; }

        public string Review { get; set; }
    }
}
