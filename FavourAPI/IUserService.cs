using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        void Add(User user);
        IEnumerable<User> GetAll();
    }
}
