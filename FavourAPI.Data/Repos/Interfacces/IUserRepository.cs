using FavourAPI.Dtos;
using System;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repos.Interfacces
{
    public interface IUserRepository : IRepository<UserDto>
    {
        Task<UserDto> GetById(Guid id);

        Task<UserDto> Create(string email, string password);

        Task<UserDto> Login(string email, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(string email);
    }
}
