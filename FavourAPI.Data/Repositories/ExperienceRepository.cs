using AutoMapper;
using FavourAPI.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public ExperienceRepository(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
        }
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
