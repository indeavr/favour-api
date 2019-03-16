using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public class WorkFavourDbContext : DbContext
    {
        public WorkFavourDbContext(DbContextOptions<WorkFavourDbContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
    }

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
    }
}
