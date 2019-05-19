using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface ICompanyProviderService
    {
        CompanyProviderDto GetProvider(string userId);

        CompanyProviderDto AddCompanyProvider(string userId, CompanyProviderDto companyProvider);
    }
}
