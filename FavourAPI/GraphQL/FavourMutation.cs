using FavourAPI.Data.Dtos.Favour;
using FavourAPI.Data.Models;
using FavourAPI.Data.Repositories;
using FavourAPI.Dtos;
using FavourAPI.GraphQL.InputTypes;
using FavourAPI.GraphQL.InputTypes.Favour;
using FavourAPI.GraphQL.Types;
using FavourAPI.Helpers;
using FavourAPI.Services;
using FavourAPI.Services.Contracts;
using Firebase.Database;
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
using System.Threading.Tasks;

namespace FavourAPI.GraphQL
{
    public class FavourMutation : ObjectGraphType<object>
    {
        public FavourMutation(IUserService userService,
            IOptions<AppSettings> appSettings,
            IProviderService providerService,
            ICompanyConsumerService companyConsumerService,
            IPersonConsumerService personConsumerService,
            IOfferService offerService,
            IFavourService favourService,
            IOfferingService offeringService
            )
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

            FieldAsync<CompanyConsumerType>("createCompanyConsumer", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                new QueryArgument<NonNullGraphType<CompanyConsumerInputType>> { Name = "companyConsumer" }
                ),
                resolve: async context =>
                {
                    var userId = context.GetArgument<string>("userId");
                    var companyConsumer = context.GetArgument<CompanyConsumerInputType>("companyConsumer");
                    var providerDto = JToken.FromObject(companyConsumer).ToObject<CompanyConsumerDto>();
                    var newProvider = await companyConsumerService
                    .AddCompanyConsumer(userId, providerDto);

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
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" },
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "firstName" },
                   new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "lastName" }
               ),
               resolve: async context =>
               {
                   var email = context.GetArgument<string>("email");
                   var password = context.GetArgument<string>("password");
                   var firstName = context.GetArgument<string>("firstName");
                   var lastName = context.GetArgument<string>("lastName");

                   var newUser = await userService.Create(email, password, firstName, lastName);
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
                       PhoneConfirmed = user.PhoneConfirmed,
                       FullName = user.FullName,
                       Permissions = user.Permissions
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
                      PhoneConfirmed = user.PhoneConfirmed,
                      FullName = user.FullName,
                      Permissions = user.Permissions
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
                      PhoneConfirmed = user.PhoneConfirmed,
                      FullName = user.FullName,
                      Permissions = user.Permissions
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

            FieldAsync<StringGraphType>(
             "createFavour",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                 new QueryArgument<NonNullGraphType<FavourInputType>> { Name = "favour" }),
             resolve: async context =>
             {
                 var userId = context.GetArgument<string>("userId");
                 var favour = context.Arguments["favour"];
                 var favourDto = JToken.FromObject(favour).ToObject<FavourDto>();

                 var success = await favourService.AddFavour(userId, favourDto);

                 return "success";
             });

            FieldAsync<StringGraphType>(
             "createOfferring",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                 new QueryArgument<NonNullGraphType<OfferingInputType>> { Name = "offering" }),
             resolve: async context =>
             {
                 var userId = context.GetArgument<string>("userId");
                 var offering = context.Arguments["offering"];
                 var offeringDto = JToken.FromObject(offering).ToObject<OfferingDto>();

                 var success = await offeringService.AddOffering(userId, offeringDto);

                 return "success";
             });

            FieldAsync<StringGraphType>(
            "createProvider",
             arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                new QueryArgument<NonNullGraphType<ProviderInputType>> { Name = "provider" }
            ),
            resolve: async context =>
            {
                var userId = context.GetArgument<string>("userId");
                var providerArg = context.Arguments["provider"];
                var provider = providerArg != null
                    ? JToken.FromObject(providerArg).ToObject<ProviderDto>()
                    : null;

                var newProvider = await providerService.AddProvider(userId, provider);
                await userService.ChangePermissions(
                    userId,
                    new List<PermissionTypes>() { PermissionTypes.HasSufficientInfoProvider, PermissionTypes.SideChosen },
                    true
                );
                return "success";
            });

           FieldAsync<StringGraphType>(
           "createPersonConsumer",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
               new QueryArgument<NonNullGraphType<PersonConsumerInputType>> { Name = "personConsumer" }
           ),
           resolve: async context =>
           {
               var userId = context.GetArgument<string>("userId");
               var consumerArg = context.Arguments["personConsumer"];
               var consumer = consumerArg != null
                   ? JToken.FromObject(consumerArg).ToObject<PersonConsumerDto>()
                   : null;

               var newConsumer = await personConsumerService.AddPersonConsumer(userId, consumer);
               await userService.ChangePermissions(
                   userId,
                   new List<PermissionTypes>() { PermissionTypes.HasSufficientInfoConsumer, PermissionTypes.SideChosen },
                   true
               );
               return "success";
           });

            FieldAsync<BooleanGraphType>(
            "applyForOffering",
             arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "offeringId" },
                new QueryArgument<NonNullGraphType<ApplicationInputType>> { Name = "application" }
            ),
            resolve: async context =>
            {
                var userId = context.GetArgument<string>("userId");
                var offeringId = context.GetArgument<string>("offeringId");
                var applicationArg = context.Arguments["application"];
                var application = applicationArg != null
                    ? JToken.FromObject(applicationArg).ToObject<ApplicationDto>()
                    : null;

                await offeringService.AddApplication(userId, offeringId, application);

                return true;
            });
        }
    }
}
