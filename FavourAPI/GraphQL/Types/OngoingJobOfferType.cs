using FavourAPI.Dtos;
using FavourAPI.Services.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class OngoingJobOfferType : ObjectGraphType<OngoingJobOfferDto>
    {
        public OngoingJobOfferType()
        {
            Field<JobOfferType>(nameof(OngoingJobOfferDto.JobOffer));
            Field<ListGraphType<ProviderType>>(nameof(OngoingJobOfferDto.Providers));
        }
    }
}
