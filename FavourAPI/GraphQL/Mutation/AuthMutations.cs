using FavourAPI.Dtos;
using FavourAPI.GraphQL.InputTypes;
using FavourAPI.Helpers;
using FavourAPI.Services;
using GraphQL.Types;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Mutation
{
    public class AuthMutations : ObjectGraphType
    { 
        public AuthMutations(IUserService userService, IOptions<AppSettings> appSettings)
        {
            Name = "Mutation";

           
        }
    }
}
