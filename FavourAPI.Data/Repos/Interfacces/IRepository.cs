using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repos.Interfacces
{
    public interface IRepository<T>
    {
        Task<T> GetById(string id);

        Task<IEnumerable<T>> GetAll();
    }
}
