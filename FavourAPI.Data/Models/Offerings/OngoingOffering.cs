using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models.Offerings
{
    public class OngoingOffering
    {
        [ForeignKey("Offering")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual IEnumerable<Period> FinalPeriods { get; set; }

        public virtual Offering Offering { get; set; }

        public virtual PersonConsumer PersonConsumer { get; set; }

        public bool IsDeleted { get; set; }
    }
}
