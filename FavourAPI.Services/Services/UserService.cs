using AutoMapper;
using FavourAPI.ApiModels;
using FavourAPI.Data;
using FavourAPI.Data.Models;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers;
using FavourAPI.Services.Helpers.Exceptions;
using FavourAPI.Services.Helpers.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public UserService([FromServices] WorkFavourDbContext workFavourDbContext, IMapper mapper)
        {
            this.dbContext = workFavourDbContext;
            this.mapper = mapper;
        }

        public async Task Add(User user)
        {
            this.dbContext.Users.Add(user);
            await this.dbContext.SaveChangesAsync();

        }

        public UserDto Authenticate(string email, string password)
        {
            //if (string.IsNullOrWhiteSpace(email))
            //    throw new EmailAppException("Email is required in order to authenticate");

            //if (string.IsNullOrWhiteSpace(password))
            //    throw new PasswordAppException("Password is required in order to authenticate");

            //var user = this.dbContext.Users.SingleOrDefault(x => x.Email == email);

            // Debug.WriteLine(this.dbContext.PermissionMys.SingleOrDefault(x => x.Id == user.Id).User.PermissionMy);
            // check if username exists
            //if (user == null)
                //throw new EmailAppException($"There is no user with such email ({email})");

            // check if password is correct
            //if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //    throw new PasswordAppException("Wrong password");

            // authentication successful
            return mapper.Map<UserDto>(null);
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return this.dbContext.Users;
        }

        public User GetById(string userId)
        {
            Guid guidUserId = Guid.Parse(userId);
            return this.dbContext.Users.Find(guidUserId);
        }

        public async Task<Result<object>> Create(string email, string password)
        {
            //if (string.IsNullOrWhiteSpace(email))
            //    return new InvalidResult<object>("Email is required !");

            //if (string.IsNullOrWhiteSpace(password))
            //    return new InvalidResult<object>("Password is required!");

            // Password validations
            // int passMinLen = 8;
            //if (password.Length < passMinLen)
            //    return new InvalidResult<object>($"Password must be at least {passMinLen} characters!");

            //if (!Regex.IsMatch(password, "[0-9]"))
            //    return new InvalidResult<object>("Password must contains at least one digit!");

            //if (email.Contains(password))
            //    return new InvalidResult<object>($"Password cannot be contained in your email address ({email})!");

            //// Email validations
            //if (!IsValidEmail(email))
            //    return new InvalidResult<object>($"Email ({email}) is not valid!");

            //if (this.dbContext.Users.Any(u => u.Email == email))
            //    return new InvalidResult<object>($"Email ({email}) is already taken!");

            // Password hashing
            //byte[] passwordHash, passwordSalt;
            //CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //User user = new User()
            //{
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt,
            //    PermissionMy = new PermissionMy(),
            //    Email = email
            //};


            //user.PermissionMy = new PermissionMy();
            ////dbContext.PermissionMys.Add(new PermissionMy() { User = user });

            //this.dbContext.Users.Add(user);
            //await this.dbContext.SaveChangesAsync();

            return new OkResult<object>(new { });
        }

        public async Task Update(User userParam, string password = null)
        {
            //var user = this.dbContext.Users.Find(userParam.Id);

            //if (user == null)
            //    throw new AppException("User not found");

            //if (userParam.Email != user.Email)
            //{
            //    // username has changed so check if the new username is already taken
            //    if (this.dbContext.Users.Any(x => x.Email == userParam.Email))
            //        throw new AppException("Username " + userParam.Email + " is already taken");
            //}

            //// update user properties
            //user.Email = userParam.Email;

            //// update password if it was entered
            //if (!string.IsNullOrWhiteSpace(password))
            //{
            //    byte[] passwordHash, passwordSalt;
            //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //    user.PasswordHash = passwordHash;
            //    user.PasswordSalt = passwordSalt;
            //}

            //this.dbContext.Users.Update(user);
            //await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(string userId)
        {
            Guid guidUserId = Guid.Parse(userId);
            var user = this.dbContext.Users.Find(guidUserId);
            if (user != null)
            {
                this.dbContext.Users.Remove(user);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdatePermissions(string userId, Action<PermissionMy> updater)
        {
            var userIdGuid = Guid.Parse(userId);
            var permission = this.dbContext.PermissionMys.Single(p => p.Id == userIdGuid);

            updater.Invoke(permission);

            this.dbContext.PermissionMys.Update(permission);

            await this.dbContext.SaveChangesAsync();
        }

        // Private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

