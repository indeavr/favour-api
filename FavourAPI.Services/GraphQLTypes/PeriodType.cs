using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class PeriodType : ObjectGraphType<PeriodDto>
    {
        public PeriodType()
        {
            Field<DateGraphType>(nameof(PeriodDto.StartDate));
            Field<DateGraphType>(nameof(PeriodDto.EndDate));
            Field<DateTimeGraphType>(nameof(PeriodDto.StartHour));
            Field<DateTimeGraphType>(nameof(PeriodDto.EndHour));
        }
    }
}
