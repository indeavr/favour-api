using FavourAPI.Dtos;
using System;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface ICompanyProviderService
    {
        Task<CompanyProviderDto> GetProvider(string userId, bool withPhoto);

        Task<CompanyProviderDto> AddCompanyProvider(string userId, CompanyProviderDto companyProvider);

        Task<string> GetProfilePhoto(string userId);
    }
}
