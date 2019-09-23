using FavourAPI.Data.Models;
using FavourAPI.Dtos;
using FavourAPI.GraphQL.InputTypes;
using FavourAPI.GraphQL.Types;
using FavourAPI.Helpers;
using FavourAPI.Services;
using GraphQL.Types;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL
{
    public class FavourMutation : ObjectGraphType<object>
    {
        public FavourMutation(IUserService userService, IOptions<AppSettings> appSettings, IConsumerService consumerService,
            ICompanyProviderService companyProviderService)
        {
            Name = "Mutation";

            FieldAsync<ConsumerType>(
                "createConsumer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ConsumerInputType>> { Name = "consumer" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" }
                ),
                resolve: async context =>
                {
                    var userId = context.GetArgument<string>("userId");
                    var consumerArg = context.Arguments["consumer"];
                    var consumer = consumerArg != null
                        ? JToken.FromObject(consumerArg).ToObject<ConsumerDto>()
                        : null;

                    var newConsumer = await consumerService.AddConsumer(userId, consumer);
                    return newConsumer;
                }
            );

            FieldAsync<CompanyProviderType>("createCompanyProvider", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                new QueryArgument<NonNullGraphType<CompanyProviderInputType>> { Name = "companyProvider" }
                ),
                resolve: async context =>
                {
                    var userId = context.GetArgument<string>("userId");
                    var provider = context.GetArgument<CompanyProviderInputType>("companyProvider");
                    var providerDto = JToken.FromObject(provider).ToObject<CompanyProviderDto>();
                    var newProvider = await companyProviderService
                    .AddCompanyProvider(userId, providerDto);

                    return newProvider;
                });

            FieldAsync<AuthPayload>(
               "register",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" },
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
               ),
               resolve: async context =>
               {
                   var email = context.GetArgument<string>("email");
                   var password = context.GetArgument<string>("password");

                   var newUser = await userService.Create(email, password);
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
