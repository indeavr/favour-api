using FavourAPI.Dtos;
using FavourAPI.Services.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Services
{
    public class SavedJobOfferType : ObjectGraphType<SavedJobOfferDto>
    {
        public SavedJobOfferType()
        {
            Field<JobOfferType>(nameof(SavedJobOfferDto.JobOffer));
            Field<ConsumerType>(nameof(SavedJobOfferDto.Consumer));
        }
    }
}
