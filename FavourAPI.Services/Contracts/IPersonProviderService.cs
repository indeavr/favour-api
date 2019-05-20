using FavourAPI.Dtos;
using System;

namespace FavourAPI.Services
{
    public interface IPersonProviderService
    {
        PersonProviderDto GetPersonProvider(Guid userId);

        void AddPersonProvider(Guid userId, PersonProviderDto personProvider);
    }
}
