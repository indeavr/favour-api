using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
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
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Token { get; set; }

        public virtual Consumer Consumer { get; set; }

        public virtual PersonProvider PersonProvider { get; set; }

        public virtual CompanyProvider CompanyProvider { get; set; }

        public virtual PermissionMy PermissionMy { get; set; }
    }
}
