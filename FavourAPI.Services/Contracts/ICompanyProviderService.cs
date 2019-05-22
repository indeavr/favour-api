using FavourAPI.Dtos;
using System;

namespace FavourAPI.Services
{
    public interface ICompanyProviderService
    {
        CompanyProviderDto GetProvider(string userId);

        CompanyProviderDto AddCompanyProvider(string userId, CompanyProviderDto companyProvider);
    }
}
