using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Queries
{
    public class CompanyProviderQuery : ObjectGraphType
    {
        public CompanyProviderQuery(ICompanyConsumerService providerService)
        {
            Field<ListGraphType<CompanyConsumerType>>("companyProviders", arguments: new QueryArguments(),
                resolve: context =>
                {
                    return providerService.GetAll();
                });

            Field<ObjectGraphType<CompanyConsumerType>>("companyProvider", arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var userdId = context.GetArgument<string>("id");

                    return providerService.GetById(userdId, true);
                });
        }
    }
}
