using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class PeriodType : ObjectGraphType<PeriodDto>
    {
        public PeriodType()
        {
            Field(a => a.StartTime, type: typeof(NonNullGraphType<DateTimeGraphType>));
            Field(a => a.EndTime, type: typeof(NonNullGraphType<DateTimeGraphType>));

            Field(a => a.StartHour, type: typeof(NonNullGraphType<DateTimeGraphType>));
            Field(a => a.StartDate, type: typeof(NonNullGraphType<DateTimeGraphType>));

            Field(a => a.EndHour, nullable: true, type: typeof(TimeSpanSecondsGraphType));
            Field(a => a.EndDate, nullable: true, type: typeof(TimeSpanSecondsGraphType));
        }
    }
}
