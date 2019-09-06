using FavourAPI.ApiModels;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class UserType : ObjectGraphType<UserDto>
    {
        public UserType()
        {
            Field(u => u.Id);
            Field(u => u.Email);
            Field<CompanyProviderType>(nameof(UserDto.CompanyProvider));
        }
    }
}
