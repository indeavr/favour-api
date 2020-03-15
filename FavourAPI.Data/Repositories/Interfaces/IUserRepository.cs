using FavourAPI.Data.Models;
using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repositories
{
    public interface IUserRepository : IRepository<UserDto>
    {
        Task<UserDto> GetById(Guid id);

        Task<UserDto> GetById(string id);

        Task<UserDto> GetByEmail(string email);

        Task<UserDto> Create(string email, string password, string firstName, string lastName);

        Task<UserDto> Login(string email, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(string email);

        Task<string> GeneratePasswordResetTokenAsync(string email);

        Task<UserDto> ChangePassword(string userId, string code, string password);

        Task SavePhoneVerificationSession(string userId, string sessionInfo);

        Task<string> GetPhoneVerificationSession(string userId);

        Task PhoneConfirmed(string userId);

        Task<UserDto> LoginWithGoogle(string serverToken);

        Task ChangePermissions(string userId, List<PermissionTypes> persmissions, bool newValue);
    }
}
