using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {

        }

        //[Key]
        //[Column(TypeName = "uniqueidentifier")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        //[EmailAddress]
        //public string Email { get; set; }

        //public string Password { get; set; }

        //public byte[] PasswordHash { get; set; }

        //public byte[] PasswordSalt { get; set; }

        public string FirebaseId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Token { get; set; }

        public string PhoneVerificationSession { get; set; }

        public string PhoneVerified { get; set; }

        public virtual Provider Provider { get; set; }

        public string LastAccountSide { get; set; }


        public virtual PersonConsumer PersonConsumer { get; set; }

        public virtual CompanyConsumer CompanyConsumer { get; set; }

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
