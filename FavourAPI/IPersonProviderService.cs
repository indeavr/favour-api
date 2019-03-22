using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IPersonProviderService
    {
        PersonProviderDto GetPersonProvider(string userId);

        void AddPersonProvider(string userId, PersonProviderDto personProvider);
    }
}
