using FavourAPI.Data.Models;
using FavourAPI.GraphQL.InputTypes;
using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using GraphQL.Types;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL
{
    public class FavourMutation : ObjectGraphType<object>
    {
        public FavourMutation(IConsumerService consumerService)
        {
            Name = "Mutation";

            Field<ConsumerType>(
                "createConsumer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ConsumerInputType>> { Name = "consumer" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" }
                ),
                resolve: context =>
                {
                    var userId = context.GetArgument<string>("userId");
                    var consumerArg = context.Arguments["consumer"];
                    var consumer = consumerArg != null
                        ? JToken.FromObject(consumerArg).ToObject<Consumer>()
                        : null;

                    var newConsumer = consumerService.AddConsumer(userId, consumer);
                    return newConsumer;
                }
            );
        }
    }
}
