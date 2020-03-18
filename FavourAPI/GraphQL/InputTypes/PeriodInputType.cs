using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class PeriodInputType : InputObjectGraphType<PeriodDto>
    {
        public PeriodInputType()
        {
            Name = "PeriodInput";
            Field(a => a.StartTime, type: typeof(NonNullGraphType<DateTimeGraphType>));
            Field(a => a.EndTime, type: typeof(NonNullGraphType<DateTimeGraphType>));
        }
    }
}
