using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class OngoingJobOfferInputType : InputObjectGraphType<OngoingJobOfferDto>
    {
        public OngoingJobOfferInputType()
        {
            Field(ojo => ojo.IsDeleted);

            Field<ListGraphType<ConsumerInputType>>(nameof(OngoingJobOfferDto.Consumers));
            Field<JobOfferInputType>(nameof(OngoingJobOfferDto.JobOffer));
        }
    }
}
