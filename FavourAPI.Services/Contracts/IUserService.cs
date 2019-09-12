using FavourAPI.Data.Models;
using FavourAPI.Dtos;
using FavourAPI.Services.Helpers.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> Create(string email, string password);

        Task<UserDto> Login(string username, string password);

        //IEnumerable<User> GetAll();

        //User GetById(string id);

        //Task UpdatePermissions(string userId, Action<PermissionMy> updater);

        //Task Update(User user, string password = null);

        //Task Delete(string id);
    }
}
