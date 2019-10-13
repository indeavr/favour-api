using AutoMapper;
using FavourAPI.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repositories
{
    public class ExperienceRepository : BaseRepository, IExperienceRepository
    {
        public ExperienceRepository(WorkFavourDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }
        public async Task<IEnumerable<ExperienceDto>> GetAll()
        {
            var allExperiences = await this.dbContext.Experiences.ToAsyncEnumerable().ToArray();

            return allExperiences.Select(e => mapper.Map<ExperienceDto>(e));
        }

        public async Task<ExperienceDto> GetById(string id)
        {
            var experience = await this.dbContext.Experiences.FindAsync(id);

            return this.mapper.Map<ExperienceDto>(experience);
        }
    }
}
