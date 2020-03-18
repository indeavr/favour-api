using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class PeriodInputType : InputObjectGraphType<PeriodDto>
    {
        public PeriodInputType()
        {
            Name = "PeriodInput";
            Field(a => a.StartHour, type: typeof(NonNullGraphType<DateTimeGraphType>));
            Field(a => a.StartDate, type: typeof(NonNullGraphType<DateTimeGraphType>));
            Field(a => a.EndHour, nullable: true, type: typeof(DateTimeGraphType));
            Field(a => a.EndDate, nullable: true, type: typeof(DateTimeGraphType));
        }
    }
}
