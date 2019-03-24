using FavourAPI.ApiModels;
using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(string id);
        void UpdatePermissions(string userId, Action<PermissionMy> updater);
        User Create(UserDto userDto, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
