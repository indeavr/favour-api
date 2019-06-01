using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Seeder.Contracts
{
    public interface IGeneratedCollections
    {
        ICollection<string> EmailCollection();
    }
}
