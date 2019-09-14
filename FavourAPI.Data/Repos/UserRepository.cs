using AutoMapper;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using FavourAPI.Data.Repos.Interfacces;
using System.Collections.Generic;

namespace FavourAPI.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserRepository(WorkFavourDbContext workFavourDbContext, UserManager<User> userManager, IMapper mapper)
        {
            this.dbContext = workFavourDbContext;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return this.mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetById(string id)
        {
            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(id));
            return this.mapper.Map<UserDto>(user);
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

            return this.mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Login(string email, string password)
        {
            var user = await this.userManager.FindByEmailAsync(email);

            bool valid = await this.userManager.CheckPasswordAsync(user, password);

            if (!valid)
            {

            }

            return this.mapper.Map<UserDto>(user);
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
