using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ApplicationInputType : InputObjectGraphType<ApplicationDto>
    {
        public ApplicationInputType()
        {
            Field(a => a.Id);
            Field(a => a.Message);

            Field<DateTimeGraphType>(nameof(ApplicationDto.Time));
            Field<ConsumerInputType>(nameof(ApplicationDto.Consumer));
            Field<ActiveJobOfferInputType>(nameof(ApplicationDto.ActiveJobOffer));
        }
    }
}
