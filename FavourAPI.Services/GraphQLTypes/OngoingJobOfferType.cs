using FavourAPI.Services.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class OngoingJobOfferType : ObjectGraphType<OngoingJobOfferDto>
    {
        public OngoingJobOfferType()
        {
            Field<JobOfferType>(nameof(OngoingJobOfferDto.JobOffer));
            Field<ListGraphType<ConsumerType>>(nameof(OngoingJobOfferDto.Consumers));
        }
    }
}
