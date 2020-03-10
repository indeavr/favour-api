using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class SavedJobOfferInputType : InputObjectGraphType<SavedJobOfferDto>
    {
        public SavedJobOfferInputType()
        {
            Field<ProviderInputType>(nameof(SavedJobOfferDto.Consumer));
            Field<ProviderInputType>(nameof(SavedJobOfferDto.JobOffer));
        }
    }
}
