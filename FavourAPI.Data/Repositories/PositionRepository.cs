using AutoMapper;
using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repositories
{
    public class PositionRepository : BaseRepository, IPositionRepository
    {
        public PositionRepository(WorkFavourDbContext dbContext, IMapper mapper) :
            base(dbContext, mapper)
        { }

        public async Task<IEnumerable<PositionDto>> GetAll()
        {
            var allPositions = await base.dbContext.Positions.ToAsyncEnumerable().ToArray();

            return allPositions.Select(p => base.mapper.Map<PositionDto>(p));
        }

        public async Task<PositionDto> GetById(string id)
        {
            var position = await base.dbContext.Positions.FindAsync(id);

            return base.mapper.Map<PositionDto>(position);
        }
    }
}
