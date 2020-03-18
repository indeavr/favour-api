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
            Name = "OfferingType";

            Field(of => of.Id);
            Field(of => of.Money);
            Field(of => of.Title);
            Field(of => of.Description);
            Field(of => of.Location, type: typeof(NonNullGraphType<LocationType>));
            Field(of => of.Provider, type: typeof(NonNullGraphType<ProviderType>));
            Field(of => of.Applications, type: typeof(NonNullGraphType<ListGraphType<ApplicationType>>));

            //Field<DateTimeGraphType>(nameof(FavourDto.TimePosted));
            //Field<ListGraphType<PeriodType>>(nameof(FavourDto.Periods));
            //Field<ListGraphType<SkillType>>(nameof(FavourDto.RequiredSkills));
            //Field<CompanyProviderType>(nameof(FavourDto.Provider));
        }
    }
}
