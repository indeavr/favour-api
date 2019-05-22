using FavourAPI.Dtos;
using System;

namespace FavourAPI.Services
{
    public interface IPersonProviderService
    {
        PersonProviderDto GetPersonProvider(string userId);

        void AddPersonProvider(string userId, PersonProviderDto personProvider);
    }
}
