using FavourAPI.Data.Repos;
using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL
{
    public class FavourQuery : ObjectGraphType
    {
        public FavourQuery(IUserRepo userRepo, IOfferService offerService, IConsumerService consumerService)
        {
            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => userRepo.Get(context.GetArgument<Guid>("id"))
            );

            Field<UserType>(
               "consumer",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
               resolve: context => 
               {
                   var consumer = consumerService.GetById(context.GetArgument<string>("userId"));
                   return consumer;
               }
           );

            Field<JobOfferType>(
                "jobOffer",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var offerId = context.GetArgument<Guid>("id");
                    if (offerId == null)
                    {
                        return offerService.GetAllOffers();
                    }
                    return offerService.GetAllOffers();
                }
            );
        }
    }
}
