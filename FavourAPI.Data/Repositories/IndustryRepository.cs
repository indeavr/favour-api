using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FavourAPI.Dtos;

namespace FavourAPI.Data.Repositories
{
    public class IndustryRepository : BaseRepository, IIndustryRepository
    {
        public IndustryRepository(WorkFavourDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<IEnumerable<IndustryDto>> GetAll()
        {
            var allIndustries = await base.dbContext.Industries.ToAsyncEnumerable().ToArray();

            return allIndustries.Select(i => base.mapper.Map<IndustryDto>(i));
        }

        public Task<IndustryDto> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
