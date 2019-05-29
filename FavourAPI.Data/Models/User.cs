using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class User
    {
        public User()
        {

        }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Token { get; set; }

        public virtual Consumer Consumer { get; set; }

        public virtual PersonProvider PersonProvider { get; set; }

        public virtual CompanyProvider CompanyProvider { get; set; }

        public virtual PermissionMy PermissionMy { get; set; }

        public virtual List<Permission> Permissions { get; set; }
        
        // Currently ignored because it introduces complex relations and can be populated simpler
        // Its value can be calculated by taking all permissions for all roles in currently active subscriptions
        // It should be present in the dto
        // public virtual List<Permission> RolePermission { get; set; }

        public virtual List<PermissionTransaction> Transactions { get; set; }

        public virtual List<Subscription> Subscriptions { get; set; }
    }
}
