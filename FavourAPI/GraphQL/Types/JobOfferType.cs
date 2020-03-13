using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class JobOfferType : ObjectGraphType<JobOfferDto>
    {
        public JobOfferType()
        {
            Field(jo => jo.Id);
            Field(jo => jo.Location);
            Field(jo => jo.Money);
            Field(jo => jo.Title);
            Field(jo => jo.Description);
            Field<DateTimeGraphType>(nameof(JobOfferDto.TimePosted));
            Field<ListGraphType<PeriodType>>(nameof(JobOfferDto.Periods));
            Field<ListGraphType<SkillType>>(nameof(JobOfferDto.RequiredSkills));
            Field<CompanyConsumerType>(nameof(JobOfferDto.CompanyConsumer));
        }
    }
}
