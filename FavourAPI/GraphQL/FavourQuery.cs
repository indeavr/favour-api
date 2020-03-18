using FavourAPI.Data.Repositories;
using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using FavourAPI.Services.Contracts;
using GraphQL.Types;
using GraphQL.Authorization;
using System;
using FavourAPI.Data.Dtos.Offerings;
using System.Collections.Generic;

namespace FavourAPI.GraphQL
{
    public class FavourQuery : ObjectGraphType
    {
        public FavourQuery(IUserRepository userRepo,
            IOfferService offerService,
            IFavourService favourService,
            IOfferingService offeringService,
            IProviderService providerService,
            ICompanyConsumerRepository companyConsumerepository, // TODO: use service not reposiotry directly !!!!
            IPersonConsumerService personConsumerService,
            IExperienceRepository experienceRepository, // TODO: use service not reposiotry directly !!!!
            IPositionRepository positionRepository, // TODO: use service not reposiotry directly !!!!
            ISkillRepository skillRepository, // TODO: use service not reposiotry directly !!!!
            IIndustryRepository industryRepository // TODO: use service not reposiotry directly !!!!
            )
        {
            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => userRepo.GetById(context.GetArgument<Guid>("id"))
            );

            FieldAsync<ProviderType>(
               "provider",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
               resolve: async context =>
              {
                  var result = await providerService.GetById(context.GetArgument<string>("userId"), true);
                  return result;
              }
           );

            FieldAsync<CompanyConsumerType>(
                "companyConsumer",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>() { Name = "id" }),
                resolve: async context =>
                {
                    var providerId = context.GetArgument<string>("id");

                    return await companyConsumerepository.GetById(providerId);
                });

            FieldAsync<CompanyConsumerType>(
             "personConsumer",
             arguments: new QueryArguments(new QueryArgument<StringGraphType>() { Name = "id" }),
             resolve: async context =>
             {
                 var consumerId = context.GetArgument<string>("id");

                 return await personConsumerService.GetById(consumerId);
             });

            Field<JobOfferType>(
                "jobOffer",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var offerId = context.GetArgument<Guid>("id");
                    if (offerId == null)
                    {
                        return offerService.GetAllOffers();
                    }
                    return offerService.GetAllOffers();
                }
            );

            Field<ListGraphType<FavourType>>(
                "favours",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var favourId = context.GetArgument<Guid>("id");
                    if (favourId == null)
                    {
                        return favourService.GetAllFavours();
                    }
                    return favourService.GetAllFavours();
                }
            );

            FieldAsync<ListGraphType<OfferingType>>(
                "offerings",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    // TODO: add filters
                    var offeringId = context.GetArgument<Guid>("id");
                    if (offeringId == null)
                    {
                        return await offeringService.GetAllActiveOfferings();
                    }
                    return await offeringService.GetAllActiveOfferings();
                }
            );

            FieldAsync<ListGraphType<ExperienceType>>(
                "experiences",
                resolve: async context =>
                {
                    return await experienceRepository.GetAll();
                });

            FieldAsync<ListGraphType<PositionType>>(
                "positions",
                resolve: async context =>
                {
                    return await positionRepository.GetAll();
                });

            FieldAsync<ListGraphType<SkillType>>(
                "skills",
                resolve: async context =>
                {
                    this.AuthorizeWith("UserPolicy");
                    return await skillRepository.GetAll();
                });

            FieldAsync<ListGraphType<IndustryType>>(
                "industries",
                resolve: async context =>
                {
                    var industriesWithPositions = await industryRepository.GetAll();
                    return industriesWithPositions;
                });

            FieldAsync<ListGraphType<OfferingType>>(
                "myActiveOfferings",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
                resolve: async context =>
                {
                    var providerId = context.GetArgument<string>("userId");
                    List<ActiveOfferingDto> myActiveOfferings = providerService.GetAllActiveOfferings(providerId);

                    return myActiveOfferings;
                });

            FieldAsync<ListGraphType<OfferingType>>(
                "myOfferingApplications",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
                resolve: async context =>
                {
                    var consumerId = context.GetArgument<string>("userId");
                    var myActiveOfferings = personConsumerService.GetApplications(consumerId);
                    return myActiveOfferings;
                });

            //FieldAsync<ListGraphType<ApplicationType>>(
            //    "applicationsOfProvider",
            //    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
            //    resolve: async context =>
            //    {
            //        var providerId = context.GetArgument<string>("userId");
            //        var providerApplications = await providerService.GetAllApplications();
            //        return providerApplications;
            //    });
        }
    }
}
