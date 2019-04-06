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
        private readonly IOfficeService officeService;

        public CompanyProviderService(WorkFavourDbContext dbContext, IMapper mapper, IOfficeService officeService)
        {
            this.mapper = mapper;
            this.officeService = officeService;
            this.dbContext = dbContext;
        }

        public CompanyProviderDto AddCompanyProvider(string userId, CompanyProviderDto companyProvider)
        {
            var dbModel = mapper.Map<CompanyProvider>(companyProvider);
            dbModel.Id = userId;

            this.dbContext.CompanyProviders.Add(dbModel);
            this.dbContext.SaveChanges();


            foreach (var office in dbModel.Offices)
            {
                this.officeService.AddIndustriesForOffice(office);
            }

            return mapper.Map<CompanyProviderDto>(dbModel);
        }

        public CompanyProviderDto GetProvider(string userId)
        {
            var provider = this.dbContext.CompanyProviders.SingleOrDefault(cp => cp.Id == userId);
            var providerDto = this.mapper.Map<CompanyProviderDto>(provider);
            providerDto.Offices = providerDto.Offices.Select(o =>
             {
                 o.Industries = this.dbContext.OfficeIndustries
                 .Where(oi => oi.OfficeId == o.Id)
                 .Select(oi => mapper.Map<IndustryDto>(oi.Industry)).ToArray();
                 return o;
             }).ToArray();
            return providerDto;
        }
    }
}
