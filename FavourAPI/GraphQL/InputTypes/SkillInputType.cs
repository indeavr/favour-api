using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class SkillInputType : InputObjectGraphType<SkillDto>
    {
        public SkillInputType()
        {
            Field(s => s.Name);
        }
    }
}
