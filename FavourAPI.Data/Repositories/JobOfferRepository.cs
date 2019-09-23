using System.Collections.Generic;
using System.Threading.Tasks;
using FavourAPI.Dtos;

namespace FavourAPI.Data.Repositories
{
    public class JobOfferRepository : IJobOfferRepository
    {
        public Task<IEnumerable<JobOfferDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<JobOfferDto> GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
