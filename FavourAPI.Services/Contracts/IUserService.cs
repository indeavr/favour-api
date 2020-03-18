using FavourAPI.Data.Models;
using FavourAPI.Data.Repositories;
using FavourAPI.Dtos;
using FavourAPI.Services.Helpers.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> Create(string email, string password, string firstName, string lastName);

        IEnumerable<UserDto> GetAll();

        Task<UserDto> Login(string email, string password);

        Task<UserDto> LoginWithGoogle(string serverToken);

        Task SendResetPasswordEmail(string email);

        Task ResetPassword(string userId, string code, string password);

        Task SavePhoneVerificationSession(string userId, string sessionInfo);

        Task<string> GetPhoneVerificationSession(string userId);

        Task PhoneConfirmed(string userId);

        //IEnumerable<User> GetAll();

        User GetById(string id);

        Task ChangePermissions(string userId, List<PermissionTypes> persmissions, bool newValue);

        //Task UpdatePermissions(string userId, Action<PermissionMy> updater);

        //Task Update(User user, string password = null);

        //Task Delete(string id);
    }
}
