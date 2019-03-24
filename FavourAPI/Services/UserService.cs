using AutoMapper;
using FavourAPI.ApiModels;
using FavourAPI.Helpers;
using FavourAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        private readonly AppSettings _appSettings;
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public UserService(IOptions<AppSettings> appSettings, [FromServices] WorkFavourDbContext workFavourDbContext, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            this.dbContext = workFavourDbContext;
            this.mapper = mapper;

        }

        public void Add(User user)
        {
            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

        }

        public UserDto Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = this.dbContext.Users.SingleOrDefault(x => x.Email == email);
            // Debug.WriteLine(this.dbContext.PermissionMys.SingleOrDefault(x => x.Id == user.Id).User.PermissionMy);
            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return mapper.Map<UserDto>(user);
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return this.dbContext.Users;
        }

        public UserDto GetById(string id)
        {
            return mapper.Map<UserDto>(this.dbContext.Users.Find(id));
        }

        public UserDto Create(UserDto userDto, string password)
        {
            var user = this.mapper.Map<User>(userDto);

            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (this.dbContext.Users.Any(x => x.Email == user.Email))
                throw new AppException("Username \"" + user.Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PermissionMy = new PermissionMy();

            //user.PermissionMy = new PermissionMy();
            //dbContext.PermissionMys.Add(new PermissionMy() { User = user });

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            return mapper.Map<UserDto>(user);
        }

        public void Update(User userParam, string password = null)
        {
            var user = this.dbContext.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Email != user.Email)
            {
                // username has changed so check if the new username is already taken
                if (this.dbContext.Users.Any(x => x.Email == userParam.Email))
                    throw new AppException("Username " + userParam.Email + " is already taken");
            }

            // update user properties
            user.Email = userParam.Email;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            this.dbContext.Users.Update(user);
            this.dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = this.dbContext.Users.Find(id);
            if (user != null)
            {
                this.dbContext.Users.Remove(user);
                this.dbContext.SaveChanges();
            }
        }

        public void UpdatePermissions(string userId, Action<PermissionMy> updater)
        {
            var permission = this.dbContext.PermissionMys.Single(p => p.Id == userId);

            updater.Invoke(permission);

            this.dbContext.SaveChanges();
        }

        // private helper methods

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
    }
}

