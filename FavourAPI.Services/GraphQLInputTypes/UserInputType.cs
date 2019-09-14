using FavourAPI.ApiModels;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLInputTypes
{
    public class UserInputType : InputObjectGraphType<UserDto>
    {
        public UserInputType()
        {
            Field(u => u.Email);
            Field(u => u.Password);
        }
    }
}
