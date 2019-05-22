using AutoMapper;
using FavourAPI.ApiModels;
using FavourAPI.Data;
using FavourAPI.Data.Models;
using FavourAPI.Services.Helpers;
using FavourAPI.Services.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public void Add(User user)
        {
            this.dbContext.User.Add(user);
            this.dbContext.SaveChanges();

        }

        public UserDto Authenticate(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new EmailAppException("Email is required in order to authenticate");

            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordAppException("Password is required in order to authenticate");

            var user = this.dbContext.User.SingleOrDefault(x => x.Email == email);
            
            // Debug.WriteLine(this.dbContext.PermissionMys.SingleOrDefault(x => x.Id == user.Id).User.PermissionMy);
            // check if username exists
            if (user == null)
                throw new EmailAppException($"There is no user with such email ({email})");

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new PasswordAppException("Wrong password");

            // authentication successful
            return mapper.Map<UserDto>(user);
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return this.dbContext.User;
        }

        public UserDto GetById(Guid id)
        {
            return mapper.Map<UserDto>(this.dbContext.User.Find(id));
        }

        public UserDto Create(UserDto userDto, string password)
        {
            if (userDto == null)
                throw new ArgumentNullException("User cannot be null");

            var user = this.mapper.Map<User>(userDto);

            // Password validations
            if (string.IsNullOrWhiteSpace(password))
                throw new PasswordAppException("Password is required!");

            int passMinLen = 8;
            if (password.Length < passMinLen)
                throw new PasswordAppException($"Password must be at least {passMinLen} characters!");

            if (!Regex.IsMatch(password, "[0-9]"))
                throw new PasswordAppException("Password must contains at least one digit!");
            
            if (userDto.Email.Contains(password))
                throw new PasswordAppException($"Password cannot be contained in your email address ({user.Email})!");

            // Email validations
            if (string.IsNullOrWhiteSpace(userDto.Email))
                throw new EmailAppException("Email is required!");

            if (IsValidEmail(userDto.Email))
                throw new EmailAppException($"Email ({user.Email}) is not valid!");

            if (this.dbContext.User.Any(u => u.Email == user.Email))
                throw new EmailAppException($"Email ({user.Email}) is already taken!");

            // Password hashing
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PermissionMy = new PermissionMy();

            //user.PermissionMy = new PermissionMy();
            //dbContext.PermissionMys.Add(new PermissionMy() { User = user });

            this.dbContext.User.Add(user);
            this.dbContext.SaveChanges();

            return mapper.Map<UserDto>(user);
        }

        public void Update(User userParam, string password = null)
        {
            var user = this.dbContext.User.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Email != user.Email)
            {
                // username has changed so check if the new username is already taken
                if (this.dbContext.User.Any(x => x.Email == userParam.Email))
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

            this.dbContext.User.Update(user);
            this.dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = this.dbContext.User.Find(id);
            if (user != null)
            {
                this.dbContext.User.Remove(user);
                this.dbContext.SaveChanges();
            }
        }

        public void UpdatePermissions(Guid userId, Action<PermissionMy> updater)
        {
            var permission = this.dbContext.PermissionMy.Single(p => p.Id == userId);

            updater.Invoke(permission);

            this.dbContext.SaveChanges();
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

