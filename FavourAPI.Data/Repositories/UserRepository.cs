﻿using AutoMapper;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using System.Collections.Generic;

namespace FavourAPI.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly UserManager<User> userManager;

        public UserRepository(WorkFavourDbContext workFavourDbContext, UserManager<User> userManager, IMapper mapper)
            : base(workFavourDbContext, mapper)
        {
            this.userManager = userManager;
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

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await this.userManager.FindByEmailAsync(email);

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

            foreach (var err in user.Errors)
            {
                throw new Exception(err.Description);
            }

            return this.mapper.Map<UserDto>(newUser);
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

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await this.userManager.FindByNameAsync(email);
            var token = await this.userManager.GeneratePasswordResetTokenAsync(user);

            return token;
        }

        public async Task<UserDto> ChangePassword(string userId, string token, string newPassword)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("No user with this is");
            }

            //var isTokenValid = await this.userManager.VerifyUserTokenAsync(user, this.userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
            //if (isTokenValid)
            //{
            await this.userManager.ResetPasswordAsync(user, token, newPassword);
            //}

            return this.mapper.Map<UserDto>(user);
        }
    }
}
