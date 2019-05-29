using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class Permission
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual User User { get; set; }

        public int CurrentCount { get; set; }

        public virtual PermissionName PermissionName { get; set; }

    }
}
