using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ApplicationInputType : InputObjectGraphType<ApplicationDto>
    {
        public ApplicationInputType()
        {
            Field(a => a.Id);
            Field(a => a.Message);

            Field<DateTimeGraphType>(nameof(ApplicationDto.Time));
            Field<ProviderInputType>(nameof(ApplicationDto.Provider));
            Field<ActiveJobOfferInputType>(nameof(ApplicationDto.ActiveJobOffer));
        }
    }
}
