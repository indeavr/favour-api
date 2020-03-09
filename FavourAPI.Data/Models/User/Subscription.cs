using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class Subscription
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }

        public double Amount { get; set; }
    }
}
