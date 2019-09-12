using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL
{
    public class FavourSchema : Schema
    {
        public FavourSchema(IDependencyResolver resolver) :base(resolver)
        {
            Query = resolver.Resolve<FavourQuery>();
            Mutation = resolver.Resolve<FavourMutation>();
        }
    }
}
