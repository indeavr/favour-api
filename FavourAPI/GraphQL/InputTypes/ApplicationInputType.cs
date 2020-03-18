using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ApplicationInputType : InputObjectGraphType<ApplicationDto>
    {
        public ApplicationInputType()
        {
            Name = "ApplicationInput";

            Field(a => a.Message);
            Field(a => a.Time, type: typeof(NonNullGraphType<ListGraphType<PeriodInputType>>));
        }
    }
}
