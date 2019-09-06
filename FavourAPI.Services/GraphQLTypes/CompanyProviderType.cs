using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class CompanyProviderType : ObjectGraphType<CompanyProviderDto>
    {
        public CompanyProviderType()
        {
            Field(cp => cp.Id);
            Field(cp => cp.Name);
            Field(cp => cp.NumberOfEmployees);
            Field(cp => cp.ProfilePhoto);
            Field(cp => cp.Bulstat);
            Field(cp => cp.FoundedYear);
            Field(cp => cp.Description);
        }
    }
}
