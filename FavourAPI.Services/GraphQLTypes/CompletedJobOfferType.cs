using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class CompletedJobOfferType : ObjectGraphType<CompletedJobOfferDto>
    {
        public CompletedJobOfferType()
        {
            Field(cjo => cjo.Id);
            Field<JobOfferType>(nameof(CompletedJobOfferDto.JobOffer));
            Field<ListGraphType<CompletionResultType>>(nameof(CompletedJobOfferDto.Results));
        }
    }
}
