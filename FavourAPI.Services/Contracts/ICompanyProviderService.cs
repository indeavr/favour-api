using FavourAPI.Dtos;
using System;

namespace FavourAPI.Services
{
    public interface ICompanyProviderService
    {
        CompanyProviderDto GetProvider(Guid userId);

        CompanyProviderDto AddCompanyProvider(Guid userId, CompanyProviderDto companyProvider);
    }
}
