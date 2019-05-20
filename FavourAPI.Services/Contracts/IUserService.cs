using FavourAPI.ApiModels;
using FavourAPI.Data.Models;
using System;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);

        IEnumerable<User> GetAll();

        UserDto GetById(Guid id);

        void UpdatePermissions(Guid userId, Action<PermissionMy> updater);

        UserDto Create(UserDto userDto, string password);

        void Update(User user, string password = null);

        void Delete(Guid id);
    }
}
