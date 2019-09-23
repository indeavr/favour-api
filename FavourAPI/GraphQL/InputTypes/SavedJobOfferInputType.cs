using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class SavedJobOfferInputType : InputObjectGraphType<SavedJobOfferDto>
    {
        public SavedJobOfferInputType()
        {
            Field<ConsumerInputType>(nameof(SavedJobOfferDto.Consumer));
            Field<ConsumerInputType>(nameof(SavedJobOfferDto.JobOffer));
        }
    }
}
