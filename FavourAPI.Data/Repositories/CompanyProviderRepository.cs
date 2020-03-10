using AutoMapper;
using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repositories
{
    public class CompanyProviderRepository : ICompanyConsumerRepository
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public CompanyProviderRepository(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CompanyConsumerDto>> GetAll()
        {
            var allProviders = await this.dbContext.CompanyProviders.ToAsyncEnumerable().ToArray();

            return allProviders.Select(ap => this.mapper.Map<CompanyConsumerDto>(ap));
        }

        public async Task<CompanyConsumerDto> GetById(string id)
        {
            var idAsGuid = Guid.Parse(id);
            var provider = await this.dbContext.CompanyProviders.FindAsync(idAsGuid);

            return this.mapper.Map<CompanyConsumerDto>(provider);
        }
    }
}
