using FavourAPI.Dtos;
using FavourAPI.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class LocationInputType : InputObjectGraphType<LocationDto>
    {   
        public LocationInputType()
        {
            Name = "LocationInput";

            //Field<NonNullGraphType<StringGraphType>>("town");

            //Field<NonNullGraphType<StringGraphType>>("country");

            //Field<NonNullGraphType<StringGraphType>>("adress");

            //Field<NonNullGraphType<StringGraphType>>("latitude");

            //Field<NonNullGraphType<StringGraphType>>("longitude");

            Field(l => l.MapsId);
            Field(l => l.Country);
            Field(l => l.Address);
            Field(l => l.Town);
            Field(l => l.Latitude);
            Field(l => l.Longitude);
        }
    }
}
