using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FavourAPI.Data;

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

        public void AddOffice(string providerId, OfficeDto office)
        {
            var officeEntity = mapper.Map<Office>(office);
            var officeIndustries = office.Industries.Select(i => new OfficeIndustry() { Industry= this.dbContext.Industries.First(), Office = officeEntity });
            officeEntity.OfficeIndustries = officeIndustries.ToArray();

            // this.dbContext.OfficeIndustries.AddRange(officeIndustries);

            this.dbContext.CompanyProviders.Single(cp => cp.Id == providerId).Offices.Add(officeEntity);

            this.dbContext.SaveChanges();
        }

        public void AddOffice(CompanyProvider provider, OfficeDto office)
        {
            var officeEntity = mapper.Map<Office>(office);
            var officeIndustries = office.Industries.Select(i => new OfficeIndustry() { IndustryId = i.Name, Office = officeEntity });

            this.dbContext.OfficeIndustries.AddRange(officeIndustries);

            provider.Offices.Add(officeEntity);

            this.dbContext.SaveChanges();
        }

        public void AddIndustriesForOffice(Office dbModel)
        {
            var officeIndustries = dbModel.Industries.Select(i => new OfficeIndustry() { Industry = this.dbContext.Industries.First(), Office = dbModel });

            this.dbContext.OfficeIndustries.AddRange(officeIndustries);

            this.dbContext.SaveChanges();
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

        private IEnumerable<IndustryDto> GetIndustriesForOffice(string officeId)
        {
            return this.dbContext.OfficeIndustries
                .Where(oi => oi.OfficeId == officeId)
                .Select(oi => oi.Industry)
                .Select(i => this.mapper.Map<IndustryDto>(i))
                .ToArray();
        }
    }
}
