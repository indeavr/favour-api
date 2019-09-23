using AutoMapper;
using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repositories
{
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(IMapper mapper, WorkFavourDbContext dbContext)
            : base(dbContext, mapper) { }

        public async Task<IEnumerable<SkillDto>> GetAll()
        {
            var allSkills = await base.dbContext.Skills.ToAsyncEnumerable().ToArray();

            return allSkills.Select(s => mapper.Map<SkillDto>(s));
        }

        public Task<SkillDto> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
