using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using GraphQL.Types;

namespace FavourAPI.Queries
{
    public class JobOfferQuery : ObjectGraphType
    {
        public JobOfferQuery(IOfferService offerService)
        {
            Field<ListGraphType<JobOfferType>>("jobOffers", arguments: new QueryArguments(),
               resolve: context =>
               {
                   return offerService.GetAllOffers();
               });

            Field<ObjectGraphType<JobOfferType>>("jobOffer", arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var jobId = context.GetArgument<string>("id");

                    return offerService.GetById(jobId);
                });
        }
    }
}
