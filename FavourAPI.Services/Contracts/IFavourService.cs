using FavourAPI.Data.Dtos.Favour;
using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Services.Contracts
{
    public interface IFavourService
    {
        Task<FavourDto> AddFavour(string Guid, FavourDto favour);

        Task<FavourDto> GetById(string favourId);

        List<FavourDto> GetAllFavours();

        Task AddApplication(string consumerId, string favourId, ApplicationDto application);
    }
}
