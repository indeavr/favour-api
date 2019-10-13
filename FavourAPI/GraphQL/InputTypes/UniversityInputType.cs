using FavourAPI.Data.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class UniversityInputType: InputObjectGraphType<UniversityDto>
    {
        public UniversityInputType()
        {
            Field(u => u.Name);
        }
    }
}
