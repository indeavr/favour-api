using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class OngoingJobOfferInputType : InputObjectGraphType<OngoingJobOfferDto>
    {
        public OngoingJobOfferInputType()
        {
            Field(ojo => ojo.IsDeleted);

            Field<ListGraphType<ProviderInputType>>(nameof(OngoingJobOfferDto.Providers));
            Field<JobOfferInputType>(nameof(OngoingJobOfferDto.JobOffer));
        }
    }
}
