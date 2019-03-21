using FavourAPI.Dtos;
using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IJobProviderService
    {
        JobProvider GetProviderByUserId(string id);

        void AddJobProviderForUser(JobProviderDto jobProvider);
    }
}
