using FavourAPI.Data.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class UniversityType : ObjectGraphType<UniversityDto>
    {
        public UniversityType()
        {
            Field(u => u.Name);
        }
    }
}
