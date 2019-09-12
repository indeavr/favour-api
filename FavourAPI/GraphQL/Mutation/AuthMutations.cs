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

            Field<UserType>(
                "register",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
                ),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    var password = context.GetArgument<string>("password");

                    var newUser = userService.Create(email, password);
                    return newUser;
                }
            );

            FieldAsync<AuthPayload>(
              "login",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" },
                  new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
              ),
              resolve: async context =>
              {
                  var email = context.GetArgument<string>("email");
                  var password = context.GetArgument<string>("password");

                  var user = await userService.Login(email, password);

                  var tokenHandler = new JwtSecurityTokenHandler();
                  var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
                  var tokenDescriptor = new SecurityTokenDescriptor
                  {
                      Subject = new ClaimsIdentity(new Claim[]
                      {
                    new Claim(ClaimTypes.Name, user.Id)
                      }),
                      Expires = DateTime.UtcNow.AddDays(7),
                      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                  };
                  var token = tokenHandler.CreateToken(tokenDescriptor);
                  var tokenString = tokenHandler.WriteToken(token);


                  var authDto = new AuthDto()
                  {
                      Token = tokenString,
                      UserId = user.Id,
                      EmailConfirmed = user.EmailConfirmed
                  };
                  return authDto;
              }
          );
        }
    }
}
