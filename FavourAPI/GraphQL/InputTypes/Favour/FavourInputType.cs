using FavourAPI.Data.Dtos.Favour;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class FavourInputType : InputObjectGraphType<FavourDto>
    {
        public FavourInputType()
        {
            Field(f => f.Title);
            Field(f => f.Description);
            Field(f => f.Money);
            Field(f => f.State);
            Field(jo => jo.Location, nullable: false, type: typeof(NonNullGraphType<LocationInputType>));


            //Field<ListGraphType<PeriodInputType>>(nameof(FavourDto.Periods));
            //Field<ListGraphType<SkillInputType>>(nameof(FavourDto.RequiredSkills));
            //Field<DateTimeGraphType>(nameof(FavourDto.TimePosted));
            //Field<CompanyProviderInputType>(nameof(FavourDto.Provider));
        }
    }
}
