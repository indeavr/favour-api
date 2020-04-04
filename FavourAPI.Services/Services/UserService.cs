using AutoMapper;
using FavourAPI.Data.Models;
using FavourAPI.Data.Repositories;
using FavourAPI.Dtos;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace FavourAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepo;
        private readonly IEmailSender emailSender;

        public UserService(IMapper mapper, IUserRepository userRepo, IEmailSender emailSender)
        {
            this.mapper = mapper;
            this.userRepo = userRepo;
            this.emailSender = emailSender;
        }


        public async Task<UserDto> Create(string email, string password, string firstName, string lastName)
        {
            var userDto = await this.userRepo.Create(email, password, firstName, lastName);

            string code = await this.userRepo.GenerateEmailConfirmationTokenAsync(email);

            string callbackUrl = $"https://127.0.0.1:44334/users/confirmEmail?userId={HttpUtility.UrlEncode(userDto.Id.ToString())}&code={HttpUtility.UrlEncode(code)}";

            //await emailSender.SendEmailAsync(userDto.Email, "Confirm your email",
            //        $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.");

            return userDto;
        }

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
            //return this.userRepo.get.Users.ToArray().Select(u => mapper.Map<UserDto>(u));
        }

        public async Task<UserDto> Login(string email, string password)
        {
            var userDto = await this.userRepo.Login(email, password);

            return userDto;
        }

        public async Task<UserDto> LoginWithGoogle(string serverToken)
        {
            var userDto = await this.userRepo.LoginWithGoogle(serverToken);

            return userDto;
        }

        public async Task SendResetPasswordEmail(string email)
        {
            var userDto = await this.userRepo.GetByEmail(email);

            var code = await this.userRepo.GeneratePasswordResetTokenAsync(email);

            string callbackUrl = $"https://localhost:3000/join/login/resetPassword?userId={HttpUtility.UrlEncode(userDto.Id.ToString())}&code={HttpUtility.UrlEncode(code)}";

            await emailSender.SendEmailAsync(userDto.Email, "Workfavour Password Reset",
                 $"Please reset your password by <a href='{callbackUrl}'>clicking here</a>.");
        }

        public async Task ResetPassword(string userId, string code, string password)
        {
            var user = await this.userRepo.ChangePassword(userId, code, password);
        }

        public async Task SavePhoneVerificationSession(string userId, string sessionInfo)
        {
            await this.userRepo.SavePhoneVerificationSession(userId, sessionInfo);
        }

        public async Task<string> GetPhoneVerificationSession(string userId)
        {
            return await this.userRepo.GetPhoneVerificationSession(userId);
        }

        public async Task PhoneConfirmed(string userId)
        {
            await this.userRepo.PhoneConfirmed(userId);
        }

        public async Task ChangePermissions(string userId, List<PermissionTypes> persmissions, bool newValue)
        {
            await this.userRepo.ChangePermissions(userId, persmissions, newValue);

        }

        public async Task SetLastLoginSide(string userId, string side)
        {
            await this.userRepo.SetLastLoginSide(userId, side);
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

        public async Task<UserDto> GetById(string id)
        {
            return await this.userRepo.GetById(id);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            return await this.userRepo.GetByEmail(email);
        }


        //private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        //private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
        //    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
        //    if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != storedHash[i]) return false;
        //        }
        //    }

        //    return true;
        //}

        //public async Task Add(User user)
        //{
        //    this.dbContext.Users.Add(user);
        //    await this.dbContext.SaveChangesAsync();
        // 
        //}
        // 
        //public UserDto AuthenticateOld(string email, string password)
        //{
        //    if (string.IsNullOrWhiteSpace(email))
        //        throw new EmailAppException("Email is required in order to authenticate");

        //    if (string.IsNullOrWhiteSpace(password))
        //        throw new PasswordAppException("Password is required in order to authenticate");

        //    var user = this.dbContext.Users.SingleOrDefault(x => x.Email == email);

        //    // Debug.WriteLine(this.dbContext.PermissionMys.SingleOrDefault(x => x.Id == user.Id).User.PermissionMy);
        //    // check if username exists
        //    //if (user == null)
        //    //throw new EmailAppException($"There is no user with such email ({email})");

        //    // check if password is correct
        //    //if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //    //    throw new PasswordAppException("Wrong password");

        //    // authentication successful
        //    return mapper.Map<UserDto>(user);
        //}

        //public IEnumerable<User> GetAll()
        //{
        //    // return users without passwords
        //    return this.dbContext.Users;
        //}

        //public User GetById(string userId)
        //{
        //    Guid guidUserId = Guid.Parse(userId);
        //    return this.dbContext.Users.Find(guidUserId);
    }

    //private void OldCreate()
    //{
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

    //}

    //public async Task Update(User userParam, string password = null)
    //{
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
    //}

    //public async Task Delete(string userId)
    //{
    //    Guid guidUserId = Guid.Parse(userId);
    //    var user = this.dbContext.Users.Find(guidUserId);
    //    if (user != null)
    //    {
    //        this.dbContext.Users.Remove(user);
    //        await this.dbContext.SaveChangesAsync();
    //    }
    //}

    //public async Task UpdatePermissions(string userId, Action<PermissionMy> updater)
    //{
    //    var userIdGuid = Guid.Parse(userId);
    //    var permission = this.dbContext.PermissionMys.Single(p => p.Id == userIdGuid);

    //    updater.Invoke(permission);

    //    this.dbContext.PermissionMys.Update(permission);

    //    await this.dbContext.SaveChangesAsync();
    //}

}

