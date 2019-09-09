using FavourAPI.Data.Models;
using FavourAPI.GraphQL.InputTypes;
using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using GraphQL.Types;
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
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name= "userId"},
                    new QueryArgument<NonNullGraphType<ConsumerInputType>> { Name= "consumer"}
                ),
                resolve: context =>
                {
                    var userId = context.GetArgument<string>("userId");
                    var consumer = context.GetArgument<Consumer>("consumer");
                    var newConsumer = consumerService.AddConsumer(userId, consumer);
                    return newConsumer;
                }
            );
        }
    }
}
