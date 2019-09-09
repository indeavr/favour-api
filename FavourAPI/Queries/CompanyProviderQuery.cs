using FavourAPI.Services;
using FavourAPI.Services.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Queries
{
    public class CompanyProviderQuery : ObjectGraphType
    {
        public CompanyProviderQuery(ICompanyProviderService providerService)
        {
            Field<ListGraphType<CompanyProviderType>>("companyProviders", arguments: new QueryArguments(),
                resolve: context =>
                {
                    return providerService.GetAll();
                });

            Field<ObjectGraphType<CompanyProviderType>>("companyProvider", arguments: new QueryArguments(new QueryArgument<IdGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    var userdId = context.GetArgument<string>("id");

                    return providerService.GetProvider(userdId, true);
                });
        }
    }
}
