using FavourAPI.Dtos;
using FavourAPI.GraphQL.Types;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class CompanyConsumerInputType : InputObjectGraphType<CompanyConsumerDto>
    {
        public CompanyConsumerInputType()
        {
            Name = "CompanyConsumerInput";

            Field(n => n.Name);
            Field(n => n.Bulstat);
            Field(n => n.Description);
            //Field<ListGraphType<OfficeInputType>>(nameof(CompanyProviderDto.Offices));
            ////Field<LocationInputType>(nameof(CompanyProviderDto.Lo));

            //Field<ListGraphType<IndustryInputType>>(nameof(CompanyProviderDto.Industries));
        }
    }
}
