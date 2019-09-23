using FavourAPI.GraphQL.Types;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ExperienceInputType : InputObjectGraphType<ExperienceType>
    {
        public ExperienceInputType()
        {
            Name = "Experience";

            Field<NonNullGraphType<StringGraphType>>("position");
        }
    }
}
