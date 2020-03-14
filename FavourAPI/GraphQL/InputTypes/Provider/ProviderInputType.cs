using FavourAPI.Dtos;
using FavourAPI.GraphQL.Types;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ProviderInputType : InputObjectGraphType<ProviderDto>
    {
        public ProviderInputType()
        {
            Name = "ProviderInput";

            //Field(c => c.ProfilePhoto);
            Field(c => c.Sex);
            Field(c => c.PhoneNumber);
            Field(jo => jo.Location, nullable: false, type: typeof(NonNullGraphType<LocationInputType>));


            //Field<ListGraphType<StringGraphType>>(nameof(ProviderDto.Skills));
            //Field<ListGraphType<ExperienceInputType>>(nameof(ProviderDto.Experiences));
            //Field<ListGraphType<EducationInputType>>(nameof(ProviderDto.Educations));
            //Field<ListGraphType<StringGraphType>>(nameof(ProviderDto.DesiredPositions));
            //Field<ListGraphType<ApplicationInputType>>(nameof(ProviderDto.Applications));
            //Field<ListGraphType<CompletedJobOfferInputType>>(nameof(ProviderDto.CompletedJobOffers));
            //Field<ListGraphType<SavedJobOfferInputType>>(nameof(ProviderDto.SavedJobOffers));
            //Field<ListGraphType<OngoingJobOfferInputType>>(nameof(ProviderDto.OngoingJobOffers));
        }
    }
}
