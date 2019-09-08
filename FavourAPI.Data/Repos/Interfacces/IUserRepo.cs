using FavourAPI.Data.Models;
using System;
using System.Threading.Tasks;

namespace FavourAPI.Data.Repos
{
    public interface IUserRepo
    {
        Task<User> Get(Guid id);
    }
}