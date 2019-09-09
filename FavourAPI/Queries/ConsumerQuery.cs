using FavourAPI.Services;
using FavourAPI.Services.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Queries
{
    public class ConsumerQuery : ObjectGraphType
    {
        public ConsumerQuery(IConsumerService consumerService)
        {
            Field<ListGraphType<ConsumerType>>("consumers", arguments: new QueryArguments(),
              resolve: context =>
              {
                  return consumerService.GetAll();
              });

            Field<ObjectGraphType<ConsumerType>>("consumer", arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var userdId = context.GetArgument<string>("id");

                    return consumerService.GetById(userdId, true);
                });
        }
    }
}
