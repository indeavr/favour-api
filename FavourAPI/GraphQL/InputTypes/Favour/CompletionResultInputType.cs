using FavourAPI.Dtos;
using GraphQL.Authorization;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class CompletionResultInputType : InputObjectGraphType<CompletionResultDto>
    {
        public CompletionResultInputType()
        {
            Field(cr => cr.Id).AuthorizeWith("SomePolicy");
            Field(cr => cr.ReviewForConsumer);
            Field(cr => cr.ReviewForProvider);
            Field(cr => cr.State);

            Field<ProviderInputType>(nameof(CompletionResultDto.Consumer));
            Field<DateTimeGraphType>(nameof(CompletionResultDto.Date));
        }
    }
}
