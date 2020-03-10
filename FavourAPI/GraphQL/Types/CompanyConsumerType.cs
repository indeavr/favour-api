using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class CompanyConsumerType : ObjectGraphType<CompanyConsumerDto>
    {
        public CompanyConsumerType()
        {
            Field(cp => cp.Id);
            Field(cp => cp.Name);
            Field(cp => cp.NumberOfEmployees);
            Field(cp => cp.ProfilePhoto);
            Field(cp => cp.Bulstat);
            Field(cp => cp.FoundedYear);
            Field(cp => cp.Description);

            Field<ListGraphType<IndustryType>>(nameof(CompanyConsumerDto.Industries));
            Field<ListGraphType<ActiveJobOfferType>>(nameof(CompanyConsumerDto.ActiveJobOffers));
            Field<ListGraphType<OngoingJobOfferType>>(nameof(CompanyConsumerDto.OngoingJobOffers));
            Field<ListGraphType<OfficeType>>(nameof(CompanyConsumerDto.Offices));
            Field<ListGraphType<PositionType>>(nameof(CompanyConsumerDto.TargetedPositions));

        }
    }
}
