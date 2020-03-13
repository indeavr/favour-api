using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class SavedJobOfferType : ObjectGraphType<SavedJobOfferDto>
    {
        public SavedJobOfferType()
        {
            Field<JobOfferType>(nameof(SavedJobOfferDto.JobOffer));
            Field<ProviderType>(nameof(SavedJobOfferDto.Consumer));
        }
    }
}
