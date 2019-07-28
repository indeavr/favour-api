using FavourAPI.Dtos;
using System;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IPersonProviderService
    {
        PersonProviderDto GetPersonProvider(string userId);

        Task AddPersonProvider(string userId, PersonProviderDto personProvider);
    }
}
