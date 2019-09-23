using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(string id);

        Task<IEnumerable<T>> GetAll();
    }
}
