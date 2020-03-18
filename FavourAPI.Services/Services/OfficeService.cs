using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FavourAPI.Data;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public OfficeService([FromServices] WorkFavourDbContext dbContext, [FromServices] IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddOffice(string providerId, OfficeDto office)
        {
            var officeEntity = mapper.Map<Office>(office);
            var officeIndustries = office.Industries.Select(i => new OfficeIndustry() { Industry = this.dbContext.Industries.First(), Office = officeEntity });
            officeEntity.OfficeIndustries = officeIndustries.ToArray();

            // this.dbContext.OfficeIndustries.AddRange(officeIndustries);

            Guid guidProvinceId = Guid.Parse(providerId);
            var companyProvider = this.dbContext.CompanyConsumers.Single(cp => cp.Id == guidProvinceId);
            companyProvider.Offices.Add(officeEntity);

            this.dbContext.CompanyConsumers.Update(companyProvider);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddOffice(CompanyConsumer provider, OfficeDto office)
        {
            var officeEntity = mapper.Map<Office>(office);
            var officeIndustries = office.Industries.Select(i => new OfficeIndustry() { IndustryId = Guid.Parse(i.Id), Office = officeEntity });

            this.dbContext.OfficeIndustries.AddRange(officeIndustries);

            provider.Offices.Add(officeEntity);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddIndustriesForOffice(Office dbModel)
        {
            var officeIndustries = dbModel.Industries.Select(i => new OfficeIndustry() { Industry = this.dbContext.Industries.First(), Office = dbModel });

            this.dbContext.OfficeIndustries.AddRange(officeIndustries);

            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<OfficeDto> GetOffices()
        {
            var selector = new Func<Office, OfficeDto>(o =>
            {
                var officeDto = mapper.Map<OfficeDto>(o);
                officeDto.Industries = GetIndustriesForOffice(o.Id).ToArray();

                return officeDto;
            });

            return this.dbContext.Offices.Select(selector).ToArray();
        }

        private IEnumerable<IndustryDto> GetIndustriesForOffice(Guid officeId)
        {
            return this.dbContext.OfficeIndustries
                .Where(oi => oi.OfficeId == officeId)
                .Select(oi => oi.Industry)
                .Select(i => this.mapper.Map<IndustryDto>(i))
                .ToArray();
        }
    }
}
