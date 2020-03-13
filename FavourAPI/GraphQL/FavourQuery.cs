using FavourAPI.Data.Repositories;
using FavourAPI.GraphQL.Types;
using FavourAPI.Services;
using FavourAPI.Services.Contracts;
using GraphQL.Types;
using GraphQL.Authorization;
using System;

namespace FavourAPI.GraphQL
{
    public class FavourQuery : ObjectGraphType
    {
        public FavourQuery(IUserRepository userRepo,
            IOfferService offerService,
            IFavourService favourService,
            IOfferingService offeringService,
            IProviderService providerService,
            ICompanyConsumerRepository companyConsumerepository,
            IExperienceRepository experienceRepository,
            IPositionRepository positionRepository,
            ISkillRepository skillRepository,
            IIndustryRepository industryRepository
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

            Field<ListGraphType<OfferingType>>(
                "offerings",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var offeringId = context.GetArgument<Guid>("id");
                    if (offeringId == null)
                    {
                        return offeringService.GetAllOfferings();
                    }
                    return offeringService.GetAllOfferings();
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
        }
    }
}
