using FavourAPI.Data.Dtos.Favour;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class OfferingType : ObjectGraphType<OfferingDto>
    {
        public OfferingType()
        {
            Name = "Offering";

            Field(jo => jo.Id);
            Field(jo => jo.Money);
            Field(jo => jo.Title);
            Field(jo => jo.Description);
            Field(f => f.Location, type: typeof(LocationType));
            //Field<DateTimeGraphType>(nameof(FavourDto.TimePosted));
            //Field<ListGraphType<PeriodType>>(nameof(FavourDto.Periods));
            //Field<ListGraphType<SkillType>>(nameof(FavourDto.RequiredSkills));
            //Field<CompanyProviderType>(nameof(FavourDto.Provider));
        }
    }
}
