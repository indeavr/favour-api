using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class Role
    {
        [Key]
        [Column(TypeName = "uniqueIdentifier")]
        public Guid Id { get; set; }

        public virtual RoleName Name { get; set; }

        public virtual IList<Subscription> Subscriptions { get; set; }

        public virtual IList<PermissionName> PermissionsForRole { get; set; }
    }
}
