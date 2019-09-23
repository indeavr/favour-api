using FavourAPI.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class LocationInputType: InputObjectGraphType<LocationType>
    {
        public LocationInputType()
        {
            Name = "LocationInput";

            Field<NonNullGraphType<StringGraphType>>("town");

            Field<NonNullGraphType<StringGraphType>>("country");

            Field<NonNullGraphType<StringGraphType>>("street");

            Field<NonNullGraphType<StringGraphType>>("zip");
        }
    }
}
