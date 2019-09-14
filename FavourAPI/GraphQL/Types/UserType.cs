﻿using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL
{
    public class UserType : ObjectGraphType<UserDto>
    {
        public UserType()
        {
            Field(u => u.Email);
            Field(u => u.EmailConfirmed);
            Field(u => u.Id, type: typeof(IdGraphType)).Description("Id of the User");
        }
    }
}
