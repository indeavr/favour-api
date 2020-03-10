using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public interface IProviderService
    {
        Task<ProviderDto> AddProvider(string userId, ProviderDto provider);

        Task<ProviderDto> AddOrUpdateProvider(string userId, ProviderDto providerData);

        Task<ProviderDto> GetById(string userId);

        Task<ProviderDto> GetById(string userId, bool withPhoto);

        Task<IEnumerable<ProviderDto>> GetAll();

        bool CheckForLoginProceedPermission(Provider provider);

        Task SaveJobOffer(string userId, string jobOfferId);

        Task<string> GetProfilePhoto(string userId);
    }
}
