using AutoMapper;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using System.Collections.Generic;
using FavourAPI.Data.Factories;
using Google.Apis.Auth;

namespace FavourAPI.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly IClaimsFactory claimsFactory;

        public UserRepository(WorkFavourDbContext workFavourDbContext,
            UserManager<User> userManager,
            IMapper mapper, IClaimsFactory claimsFactory)
            : base(workFavourDbContext, mapper)
        {
            this.userManager = userManager;
            this.claimsFactory = claimsFactory;
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await GetByIdDb(id);
            return this.mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetById(string id)
        {
            var user = await GetByIdDb(id);
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

            await this.userManager.AddClaimAsync(user, this.claimsFactory.CreateAuthenticatedClaim());

            if (!valid)
            {

            }

            return this.mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> LoginWithGoogle(string email, string serverToken)
        {
            var authPayload = await GoogleJsonWebSignature.ValidateAsync(serverToken);
            var user = await this.userManager.FindByEmailAsync(authPayload.Email);

            if (user == null)
            {
                var newUser = await this.userManager.CreateAsync(new User()
                {
                    Email = authPayload.Email,
                    UserName = authPayload.Name
                });

                foreach (var err in newUser.Errors)
                {
                    throw new Exception(err.Description);
                }
                return this.mapper.Map<UserDto>(newUser);
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

        public async Task SavePhoneVerificationSession(string userId, string sessionInfo)
        {
            await UpdateUser(userId, (user) =>
            {
                user.PhoneVerificationSession = sessionInfo;
            });
        }

        public async Task<string> GetPhoneVerificationSession(string userId)
        {
            var user = await GetByIdDb(userId);

            return user.PhoneVerificationSession;
        }

        public async Task PhoneConfirmed(string userId)
        {
            await UpdateUser(userId, (user) =>
            {
                user.PhoneNumberConfirmed = true;
            });
        }

        private async Task<User> GetByIdDb(Guid id)
        {
            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        private async Task<User> GetByIdDb(string id)
        {
            if (id == null)
            {
                return null;
            }
            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(id));
            return user;
        }

        private async Task UpdateUser(string userId, Action<User> updateAction)
        {
            var user = await GetByIdDb(userId);

            updateAction(user);

            await this.userManager.UpdateAsync(user);
        }

        public async Task<UserDto> LoginWithGoogle(string email, string serverToken)
        {
            var authPayload = await GoogleJsonWebSignature.ValidateAsync(serverToken);
            var user = await this.userManager.FindByEmailAsync(authPayload.Email);

            if (user == null)
            {
                var newUser = await this.userManager.CreateAsync(new User()
                {
                    Email = authPayload.Email,
                    UserName = authPayload.Name
                });

                foreach (var err in newUser.Errors)
                {
                    throw new Exception(err.Description);
                }
                return this.mapper.Map<UserDto>(newUser);
            }

            return this.mapper.Map<UserDto>(user);
        }
    }
}
