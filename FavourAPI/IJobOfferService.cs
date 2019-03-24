using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IJobOfferService
    {
        List<JobOffer> Get();
    }
}
