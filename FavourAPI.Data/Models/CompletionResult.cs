using FavourAPI.Data.Models.Enums;
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

        public string ReviewForConsumer { get; set; }

        public string ReviewForProvider { get; set; }

        public virtual CompletionResultStateDb State { get; set; }
    }
}
