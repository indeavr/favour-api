using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class CompletionResultInputType: InputObjectGraphType<CompletionResultDto>
    {
        public CompletionResultInputType()
        {
            Field(cr => cr.Id);
            Field(cr => cr.ReviewForConsumer);
            Field(cr => cr.ReviewForProvider);
            Field(cr => cr.State);

            Field<ConsumerInputType>(nameof(CompletionResultDto.Consumer));
            Field<DateTimeGraphType>(nameof(CompletionResultDto.Date));
        }
    }
}
