﻿using System;
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

        public Guid? ConsumerId { get; set; }
        public Guid? PersonProviderId { get; set; }
        public Guid? CompanyProviderId { get; set; }
        public Guid? PermissionMyId { get; set; }

        public virtual Consumer Consumer { get; set; }
        public virtual PersonProvider PersonProvider { get; set; }
        public virtual CompanyProvider CompanyProvider { get; set; }
        public virtual PermissionMy PermissionMy { get; set; }
    }
}
