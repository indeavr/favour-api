using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Models;

namespace FavourAPI.Services
{
    public class CompanyProviderService : ICompanyProviderService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public CompanyProviderService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void AddCompanyProvider(string userId, CompanyProviderDto companyProvider)
        {
            var dbModel = mapper.Map<CompanyProvider>(companyProvider);
            dbModel.Id = userId;

            this.dbContext.CompanyProviders.Add(dbModel);
            this.dbContext.SaveChanges();
        }

        public CompanyProviderDto GetProvider(string userId)
        {
            var provider = this.dbContext.CompanyProviders.SingleOrDefault(cp => cp.Id == userId);

            return this.mapper.Map<CompanyProviderDto>(provider);
        }
    }
}
