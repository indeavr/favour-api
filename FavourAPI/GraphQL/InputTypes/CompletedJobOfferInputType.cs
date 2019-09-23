using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class CompletedJobOfferInputType : InputObjectGraphType<CompletedJobOfferDto>
    {
        public CompletedJobOfferInputType()
        {
            Field(cjo => cjo.Id);
            Field<ListGraphType<CompletionResultInputType>>(nameof(CompletedJobOfferDto.Results));
            Field<JobOfferInputType>(nameof(CompletedJobOfferDto.JobOffer));
        }
    }
}
