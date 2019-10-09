using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class JobOfferInputType : InputObjectGraphType<JobOfferDto>
    {
        public JobOfferInputType()
        {
            Name = "JobOffer";

            Field<StringGraphType>(nameof(JobOfferDto.Id));
            Field(jo => jo.Money);
            Field(jo => jo.Location);
            Field(jo => jo.State);
            Field(jo => jo.Title);
            Field(jo => jo.Description);

            Field<ListGraphType<PeriodInputType>>(nameof(JobOfferDto.Periods));
            Field<ListGraphType<SkillInputType>>(nameof(JobOfferDto.RequiredSkills));
            Field<DateTimeGraphType>(nameof(JobOfferDto.TimePosted));
            Field<CompanyProviderInputType>(nameof(JobOfferDto.Provider));
        }
    }
}
