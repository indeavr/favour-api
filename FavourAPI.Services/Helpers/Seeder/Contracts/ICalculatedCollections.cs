using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder.Contracts
{
    public interface ICalculatedCollections
    {
        ICollection<string> UsersPasswords();
        ICollection<byte[]> UsersPasswordHashes();
        ICollection<byte[]> UsersPasswordSalts();
    }
}
