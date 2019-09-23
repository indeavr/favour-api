using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class PeriodInputType : InputObjectGraphType<PeriodDto>
    {
        public PeriodInputType()
        {
            Field(p => p.Id);

            Field<DateTimeGraphType>(nameof(PeriodDto.StartHour));
            Field<DateTimeGraphType>(nameof(PeriodDto.StartDate));
            Field<DateTimeGraphType>(nameof(PeriodDto.EndHour));
            Field<DateTimeGraphType>(nameof(PeriodDto.EndDate));
        }
    }
}
