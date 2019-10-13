using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class EducationInputType : InputObjectGraphType<EducationDto>
    {
        public EducationInputType()
        {
            Name = "Education";

            Field(e => e.Id);

            Field<FieldOfStudyInputType>(nameof(EducationDto.Field));
            Field<DateTimeGraphType>(nameof(EducationDto.Start));
            Field<DateTimeGraphType>(nameof(EducationDto.End));
            Field<UniversityInputType>(nameof(EducationDto.University));
        }
    }
}
