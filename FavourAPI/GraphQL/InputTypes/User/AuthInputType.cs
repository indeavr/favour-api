using FavourAPI.Dtos;
using FavourAPI.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class AuthPayload : ObjectGraphType<AuthDto> // TODO: this is not an Input Type
    {
        public AuthPayload()
        {
            Name = "AuthPayloadType";

            Field<NonNullGraphType<StringGraphType>>("token");

            Field<NonNullGraphType<StringGraphType>>("firebaseToken");

            Field<NonNullGraphType<StringGraphType>>("userId");

            Field<NonNullGraphType<StringGraphType>>("firebaseId");

            Field<NonNullGraphType<StringGraphType>>("fullName");

            Field<StringGraphType>("lastAccountSide");

            Field(jo => jo.Permissions, nullable: false, type: typeof(NonNullGraphType<PermissionsType>));
        }
    }
}