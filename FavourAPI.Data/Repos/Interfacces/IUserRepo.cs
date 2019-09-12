using FavourAPI.Data.Models;
using FavourAPI.Dtos;
using System;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repos
{
    public interface IUserRepo
    {
        Task<UserDto> Get(Guid id);

        Task<UserDto> Create(string email, string password);

        Task<UserDto> Login(string email, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(string email);
    }
}