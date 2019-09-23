using FavourAPI.Dtos;
using FavourAPI.GraphQL.Types;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ConsumerInputType : InputObjectGraphType<ConsumerDto>
    {
        public ConsumerInputType()
        {
            Name = "Consumer";

            Field(c => c.Id);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field(c => c.ProfilePhoto);
            Field(c => c.Sex);
            Field(c => c.PhoneNumber);

            Field<ListGraphType<StringGraphType>>(nameof(ConsumerDto.Skills));
            Field<LocationInputType>(nameof(ConsumerDto.Location));
            Field<ListGraphType<ExperienceInputType>>(nameof(ConsumerDto.Experiences));
            Field<ListGraphType<EducationInputType>>(nameof(ConsumerDto.Educations));
            Field<ListGraphType<StringGraphType>>(nameof(ConsumerDto.DesiredPositions));
            Field<ListGraphType<ApplicationInputType>>(nameof(ConsumerDto.Applications));
            Field<ListGraphType<CompletedJobOfferInputType>>(nameof(ConsumerDto.CompletedJobOffers));
            Field<ListGraphType<SavedJobOfferInputType>>(nameof(ConsumerDto.SavedJobOffers));
            Field<ListGraphType<OngoingJobOfferInputType>>(nameof(ConsumerDto.OngoingJobOffers));
        }
    }
}
