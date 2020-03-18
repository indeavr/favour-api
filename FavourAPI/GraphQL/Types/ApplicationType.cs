using FavourAPI.Dtos;
using FavourAPI.Services.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class ApplicationType : ObjectGraphType<ApplicationDto>
    {
        public ApplicationType()
        {
            Field(a => a.Id);
            Field(a => a.Message);
            Field<DateTimeGraphType>(nameof(ApplicationDto.Time));
            Field<ProviderType>(nameof(ApplicationDto.PersonConsumer));
        }
    }
}
