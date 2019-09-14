using System.Collections.Generic;
using System.Threading.Tasks;
using FavourAPI.Data.Repos.Interfacces;
using FavourAPI.Dtos;

namespace FavourAPI.Data.Repos
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
