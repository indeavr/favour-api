using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ExperienceInputType : InputObjectGraphType<ExperienceDto>
    {
        public ExperienceInputType()
        {
            Name = "Experience";

            Field(e => e.CompanyName);
            Field(e => e.CurrentlyWorking);
            Field(e => e.Description);
            Field(e => e.Position);

            Field<DateTimeGraphType>(nameof(ExperienceDto.Start));
            Field<DateTimeGraphType>(nameof(ExperienceDto.End));
        }
    }
}
