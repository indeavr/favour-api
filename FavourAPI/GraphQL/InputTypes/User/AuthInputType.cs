using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class AuthPayload : ObjectGraphType<AuthDto>
    {
        public AuthPayload()
        {
            Name = "auth";

            Field<NonNullGraphType<StringGraphType>>("token");

            Field<NonNullGraphType<StringGraphType>>("userId");
        }
    }
}