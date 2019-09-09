using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface ICompanyProviderService
    {
        Task<IEnumerable<CompanyProviderDto>> GetAll();

        Task<CompanyProviderDto> GetProvider(string userId, bool withPhoto);

        Task<CompanyProviderDto> AddCompanyProvider(string userId, CompanyProviderDto companyProvider);

        Task<string> GetProfilePhoto(string userId);

        ProviderViewTimeDto GetViewTime(string userId);

        Task AddOrUpdateViewTime(string userId, ProviderViewTimeDto viewTime);
    }
}
