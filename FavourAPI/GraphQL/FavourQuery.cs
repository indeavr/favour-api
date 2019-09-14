using FavourAPI.Data.Repos.Interfacces;
using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using GraphQL.Types;
using System;

namespace FavourAPI.GraphQL
{
    public class FavourQuery : ObjectGraphType
    {
        public FavourQuery(IUserRepository userRepo, IOfferService offerService, IConsumerService consumerService)
        {
            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => userRepo.GetById(context.GetArgument<Guid>("id"))
            );

            Field<ConsumerType>(
               "consumer",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
               resolve: context => 
               {
                   var result = consumerService.GetById(context.GetArgument<string>("userId"), false);
                   if (result.Exception != null)
                   {
                       return result.Exception;
                   }
                   return result.Result;
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
