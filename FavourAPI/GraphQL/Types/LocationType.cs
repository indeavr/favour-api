using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class LocationType : ObjectGraphType<LocationDto>
    {
        public LocationType()
        {
            Field(l => l.Country);
            Field(l => l.StreetAddress);
            Field(l => l.Town);
            Field(l => l.ZipCode);
        }
    }
}
