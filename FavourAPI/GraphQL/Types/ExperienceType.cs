using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class ExperienceType : ObjectGraphType<ExperienceDto>
    {
        public ExperienceType()
        {
            Field(e => e.Id);
            Field(e => e.CompanyName);
            Field(e => e.CurrentlyWorking);
            Field(e => e.Description);
            Field(e => e.Position);

            Field<DateTimeGraphType>(nameof(ExperienceDto.Start));
            Field<DateTimeGraphType>(nameof(ExperienceDto.End));
            Field<ProviderType>(nameof(ExperienceDto.Consumer));
        }
    }
}
