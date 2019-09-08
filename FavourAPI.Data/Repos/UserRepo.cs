using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly UserManager<User> userManager;

        public UserRepo(WorkFavourDbContext workFavourDbContext, UserManager<User> userManager)
        {
            this.dbContext = workFavourDbContext;
            this.userManager = userManager;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
