using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class CompletionResultType : ObjectGraphType<CompletionResultDto>
    {
        public CompletionResultType()
        {
            Field(cr => cr.Id);
            Field(cr => cr.ReviewForConsumer);
            Field(cr => cr.ReviewForProvider);
            Field(cr => cr.State);

            Field<ProviderType>(nameof(CompletionResultDto.Consumer));
            Field<DateTimeGraphType>(nameof(CompletionResultDto.Date));
        }
    }
}
