using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models.Offerings
{
    public class CompletedOffering
    {
        [ForeignKey("Offering")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual Offering Offering { get; set; }

        public virtual ICollection<CompletionResult> Results { get; set; }
    }
}
