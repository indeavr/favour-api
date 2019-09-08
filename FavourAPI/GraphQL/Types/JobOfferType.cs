using FavourAPI.Data.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class JobOfferType : ObjectGraphType<JobOffer>
    {
        public JobOfferType()
        {
            Field(j => j.Title);
            Field(j => j.Provider);
            Field(j => j.Money);
        }
    }
}
