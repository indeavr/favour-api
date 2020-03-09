using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class PermissionTransaction
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public double MoneyPerItem { get; set; }

        public virtual PermissionName Permission { get; set; }

        public int ItemCount { get; set; }

        public virtual User User { get; set; }
    }
}
