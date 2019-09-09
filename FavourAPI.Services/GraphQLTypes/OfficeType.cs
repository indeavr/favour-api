using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class OfficeType : ObjectGraphType<OfficeDto>
    {
        public OfficeType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field<LocationType>(nameof(OfficeDto.Location));
            Field<ListGraphType<IndustryType>>(nameof(OfficeDto.Industries));
            Field<ListGraphType<EmailType>>(nameof(OfficeDto.Emails));
            Field<ListGraphType<PhoneNumerType>>(nameof(OfficeDto.PhoneNumbers));

        }

    }
}
