using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using GraphQL.Types;


namespace FavourAPI.Queries
{
    public class ConsumerQuery : ObjectGraphType
    {
        public ConsumerQuery(IProviderService consumerService)
        {
            Field<ListGraphType<ProviderType>>("consumers", arguments: new QueryArguments(),
              resolve: context =>
              {
                  return consumerService.GetAll();
              });

            Field<ObjectGraphType<ProviderType>>("consumer", arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var userdId = context.GetArgument<string>("id");

                    return consumerService.GetById(userdId, true);
                });
        }
    }
}
