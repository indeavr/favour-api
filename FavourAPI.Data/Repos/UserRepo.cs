using AutoMapper;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FavourAPI.Dtos;

namespace FavourAPI.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserRepo(WorkFavourDbContext workFavourDbContext, UserManager<User> userManager)
        {
            this.dbContext = workFavourDbContext;
            this.userManager = userManager;
        }

        public async Task<UserDto> Get(Guid id)
        {
            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return mapper.Map<UserDto>(user);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await this.userManager.FindByEmailAsync(email);
            string token = await this.userManager.GenerateEmailConfirmationTokenAsync(user);

            return token;
        }

        public async Task<UserDto> Create(string email, string password)
        {
            var newUser = new User() { Email = email, UserName = email };

            var user = await this.userManager.CreateAsync(newUser, password);

            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Login(string email, string password)
        {
            var user = await this.userManager.FindByEmailAsync(email);

            bool valid = await this.userManager.CheckPasswordAsync(user, password);

            if (!valid)
            {

            }

            return mapper.Map<UserDto>(user);
        }

    }
}
