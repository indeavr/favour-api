using FavourAPI.Dtos;
using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface ICompanyProviderService
    {
        CompanyProviderDto GetProvider(string userId);

        CompanyProviderDto AddCompanyProvider(string userId, CompanyProviderDto companyProvider);
    }
}
