using FavourAPI.Dtos;
using FavourAPI.Services.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class ProviderType : ObjectGraphType<ProviderDto>
    {
        public ProviderType()
        {
            Name = "Provider";

            Field(c => c.Id);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field(c => c.PhoneNumber);
            Field(c => c.ProfilePhoto);
            Field(c => c.Sex);

            Field<LocationType>(nameof(ProviderDto.Location));
            Field<ListGraphType<StringGraphType>>(nameof(ProviderDto.Skills));
            Field<ListGraphType<SavedJobOfferType>>(nameof(ProviderDto.SavedJobOffers));
            Field<ListGraphType<OngoingJobOfferType>>(nameof(ProviderDto.OngoingJobOffers));
        }
    }
}
