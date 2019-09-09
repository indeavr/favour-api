using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.Services.GraphQLTypes
{
    public class CompanyProviderType : ObjectGraphType<CompanyProviderDto>
    {
        public CompanyProviderType()
        {
            Field(cp => cp.Id);
            Field(cp => cp.Name);
            Field(cp => cp.NumberOfEmployees);
            Field(cp => cp.ProfilePhoto);
            Field(cp => cp.Bulstat);
            Field(cp => cp.FoundedYear);
            Field(cp => cp.Description);

            Field<ListGraphType<IndustryType>>(nameof(CompanyProviderDto.Industries));
            Field<ListGraphType<ActiveJobOfferType>>(nameof(CompanyProviderDto.ActiveJobOffers));
            Field<ListGraphType<OngoingJobOfferType>>(nameof(CompanyProviderDto.OngoingJobOffers));
            Field<ListGraphType<OfficeType>>(nameof(CompanyProviderDto.Offices));
            Field<ListGraphType<PositionType>>(nameof(CompanyProviderDto.TargetedPositions));

        }
    }
}
