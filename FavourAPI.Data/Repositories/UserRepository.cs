﻿using AutoMapper;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using System.Collections.Generic;
using FavourAPI.Data.Factories;
using Google.Apis.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Newtonsoft.Json;
using Firebase.Database;

namespace FavourAPI.Data.Repositories
{
    public enum PermissionTypes
    {
        HasSufficientInfoProvider,
        HasSufficientInfoConsumer,
        SideChosen,
    }

    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly IClaimsFactory claimsFactory;
        private readonly WorkFavourDbContext dbContext;

        public UserRepository(WorkFavourDbContext workFavourDbContext,
            UserManager<User> userManager,
            IMapper mapper,
            IClaimsFactory claimsFactory)
            : base(workFavourDbContext, mapper)
        {
            this.userManager = userManager;
            this.dbContext = workFavourDbContext;
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

        public async Task<UserDto> Create(string email, string password, string firstName, string lastName)
        {
            var permissionsMy = new PermissionMy()
            {
                SideChosen = false,
                HasSufficientInfoProvider = false,
                HasSufficientInfoConsumer = false,
                CanApplyConsumer = true,
            };

            this.dbContext.PermissionMys.Add(permissionsMy);

            var newUser = new User()
            {
                Email = email,
                UserName = email,
                FullName = $"{firstName} {lastName}",
                FirstName = firstName,
                LastName = lastName,
                PermissionMy = permissionsMy
            };

            var user = password == null
                ? await this.userManager.CreateAsync(newUser)
                : await this.userManager.CreateAsync(newUser, password);

            foreach (var err in user.Errors)
            {
                throw new Exception(err.Description);
            }

            var userDto = this.mapper.Map<UserDto>(newUser);

            this.CreateUserInFirebase(userDto);

            return userDto;
        }

        public async Task<UserDto> Login(string email, string password)
        {
            var user = await this.userManager.FindByEmailAsync(email);

            bool valid = await this.userManager.CheckPasswordAsync(user, password);

            await this.userManager.AddClaimAsync(user, this.claimsFactory.CreateAuthenticatedClaim());

            if (!valid)
            {
                throw new Exception("No user");
            }

            return this.mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> LoginWithGoogle(string serverToken)
        {
            var validatedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(serverToken);
            var googleUser = await FirebaseAuth.DefaultInstance.GetUserAsync(validatedToken.Uid);
            // var authPayload = await GoogleJsonWebSignature.ValidateAsync(serverToken, forceGoogleCertRefresh: true);
            var user = await this.userManager.FindByEmailAsync(googleUser.Email);

            if (user == null)
            {
                string[] names = googleUser.DisplayName.Split(" ");

                UserDto newUser = await this.Create(
                    googleUser.Email,
                    null,
                    names[0],
                    names.Length > 1 ? names[1] : ""
                );

                return newUser;
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

        public async Task ChangePermissions(string userId, List<PermissionTypes> persmissions, bool newValue)
        {
            await UpdateUser(userId, (user) =>
            {
                foreach (var persmission in persmissions)
                {
                    switch (persmission)
                    {
                        case PermissionTypes.HasSufficientInfoConsumer:
                            user.PermissionMy.HasSufficientInfoConsumer = newValue;
                            break;
                        case PermissionTypes.HasSufficientInfoProvider:
                            user.PermissionMy.HasSufficientInfoProvider = newValue;
                            break;
                        case PermissionTypes.SideChosen:
                            user.PermissionMy.SideChosen = newValue;
                            break;
                    }
                }
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
            var user = await this.userManager.FindByIdAsync(id);
            return user;
        }

        private async Task UpdateUser(string userId, Action<User> updateAction)
        {
            var user = await GetByIdDb(userId);

            updateAction(user);

            await this.userManager.UpdateAsync(user);
        }

        private async Task CreateUserInFirebase(UserDto user)
        {
            // TODO: make this env variable
            var auth = "";
            var firebaseClient = new FirebaseClient(
                "https://all-favour.firebaseio.com/",
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(auth)
                });

            var json = JsonConvert.SerializeObject(new
            {
                fullName = user.FullName
            });

            await firebaseClient
                 .Child($"users/{user.Id}")
                 .PutAsync(json);
        }
    }
}
