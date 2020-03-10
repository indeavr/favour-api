using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class LocationType : ObjectGraphType<LocationDto>
    {
        public LocationType()
        {
            Field(l => l.Country);
            Field(l => l.Address);
            Field(l => l.Town);
            Field(l => l.Latitude);
            Field(l => l.Longitude);
            Field(l => l.Id);
            Field(l => l.MapsId);
            Field(l => l.ZipCode);
        }
    }
}
