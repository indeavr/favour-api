using FavourAPI.Dtos;
using FavourAPI.Services.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class ConsumerType : ObjectGraphType<ConsumerDto>
    {
        public ConsumerType()
        {
            Field(c => c.Id);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field(c => c.PhoneNumber);
            Field(c => c.ProfilePhoto);
            Field(c => c.Sex);

            Field<LocationType>(nameof(ConsumerDto.Location));
            Field<ListGraphType<StringGraphType>>(nameof(ConsumerDto.Skills));
            Field<ListGraphType<SavedJobOfferType>>(nameof(ConsumerDto.SavedJobOffers));
            Field<ListGraphType<OngoingJobOfferType>>(nameof(ConsumerDto.OngoingJobOffers));
        }
    }
}
