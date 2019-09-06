using FavourAPI.ApiModels;
using FavourAPI.Data.Models;
using FavourAPI.Services.Helpers.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);

        IEnumerable<UserDto> GetAll();

        UserDto GetById(string id);

        Task UpdatePermissions(string userId, Action<PermissionMy> updater);

        Task<Result<object>> Create(string email, string password);

        Task Update(User user, string password = null);

        Task Delete(string id);
    }
}
