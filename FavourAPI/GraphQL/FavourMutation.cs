using FavourAPI.Data.Models;
using FavourAPI.Dtos;
using FavourAPI.GraphQL.InputTypes;
using FavourAPI.GraphQL.Types;
using FavourAPI.Helpers;
using FavourAPI.Services;
using GraphQL.Types;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace FavourAPI.GraphQL
{
    public class FavourMutation : ObjectGraphType<object>
    {
        public FavourMutation(IUserService userService,
            IOptions<AppSettings> appSettings,
            IConsumerService consumerService,
            ICompanyProviderService companyProviderService,
            IOfferService offerService)
        {
            Name = "Mutation";

            FieldAsync<StringGraphType>(
                "sendVerificationCode",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "phoneNumber" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "recapchaToken" },
                    new QueryArgument<StringGraphType> { Name = "userId" }
                ),
                resolve: async (context) =>
                {
                    var graphUserContext = (GraphQLUserContext)context.UserContext;

                    string phoneNumber = context.GetArgument<string>("phoneNumber");
                    string recapchaToken = context.GetArgument<string>("recapchaToken");

                    string userId = graphUserContext.UserId;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("https://localhost:3000");
                    client.DefaultRequestHeaders.Add("Origin", "https://localhost:3000");
                    client.DefaultRequestHeaders.Referrer = new Uri("https://localhost:3000/confirmNumber");

                    client.DefaultRequestHeaders.Add("DNT", "1");
                    client.DefaultRequestHeaders.Add("X-Client-Version", "Chrome/JsCore/7.2.0/FirebaseCore-web");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");

                    var jobject = new JObject();
                    jobject.Add("phoneNumber", new JValue(phoneNumber));
                    jobject.Add("recaptchaToken", new JValue(recapchaToken));

                    var content = new StringContent(jobject.ToString(), Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var apiKey = "AIzaSyDvGTpiP9LXmd6KaCQ88jJ0gm9q5bN4j1k";
                    var response = await client.PostAsync($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/sendVerificationCode?key={apiKey}", content);

                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    string sessionInfo = json["sessionInfo"].Value<string>();

                    await userService.SavePhoneVerificationSession(userId, sessionInfo);

                    return "success";
                }
            );


            FieldAsync<StringGraphType>(
               "verifyPhoneNumber",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code" },
                   new QueryArgument<StringGraphType> { Name = "userId" }
               ),
               resolve: async context =>
               {
                   var graphUserContext = (GraphQLUserContext)context.UserContext;

                   string code = context.GetArgument<string>("code");
                   string userId = graphUserContext.UserId;

                   var sessionToken = await userService.GetPhoneVerificationSession(userId);

                   var values = new Dictionary<string, string>
                   {
                        { "code", code },
                        { "phoneNumber", "+359888888888" },
                        { "sessionInfo", sessionToken },
                   };
                   var content = new FormUrlEncodedContent(values);

                   var apiKey = "AIzaSyDSKG4GcWm6dd_wQ-DLoNQqwvYq6KSkH-w";

                   HttpClient client = new HttpClient();
                   var response = await client.PostAsync($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPhoneNumber?key={apiKey}", content);

                   var responseString = await response.Content.ReadAsStringAsync();

                   if ((int)response.StatusCode == 200)
                   {
                       await userService.PhoneConfirmed(userId);
                       return "success";
                   }

                   return "failed";
               }
           );

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

            FieldAsync<StringGraphType>(
               "sendResetPasswordEmail",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }
               ),
               resolve: async context =>
               {
                   var email = context.GetArgument<string>("email");

                   await userService.SendResetPasswordEmail(email);

                   return "belisima";
               }
           );

            FieldAsync<StringGraphType>(
              "resetPassword",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                  new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code" },
                  new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
              ),
              resolve: async context =>
              {
                  var userId = context.GetArgument<string>("userId");
                  var code = context.GetArgument<string>("code");
                  var password = context.GetArgument<string>("password");

                  await userService.ResetPassword(userId, code, password);

                  return "belisima";
              }
          );

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
                       EmailConfirmed = user.EmailConfirmed,
                       PhoneConfirmed = user.PhoneConfirmed
                   };
                   return authDto;
               }
           );

            FieldAsync<AuthPayload>(
              "loginWithGoogle",
              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "serverToken" }
              ),
              resolve: async context =>
              {
                  var serverToken = context.GetArgument<string>("serverToken");

                  var user = await userService.LoginWithGoogle(serverToken);

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
                      EmailConfirmed = user.EmailConfirmed,
                      PhoneConfirmed = user.PhoneConfirmed
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
                      EmailConfirmed = user.EmailConfirmed,
                      PhoneConfirmed = user.PhoneConfirmed
                  };
                  return authDto;
              }


          );

            FieldAsync<JobOfferType>(
               "createJob",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                   new QueryArgument<NonNullGraphType<JobOfferInputType>> { Name = "jobOffer" }),
               resolve: async context =>
               {
                   var userId = context.GetArgument<string>("userId");
                   var job = context.GetArgument<JobOfferInputType>("jobOffer");
                   var jobDto = JToken.FromObject(job).ToObject<JobOfferDto>();

                   return await offerService.AddJobOffer(userId, jobDto);
               });
        }
    }
}
