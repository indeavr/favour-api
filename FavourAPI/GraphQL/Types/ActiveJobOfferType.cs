using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class ActiveJobOfferType : ObjectGraphType<ActiveJobOfferDto>
    {
        public ActiveJobOfferType()
        {
            Field(ajo => ajo.Id);
            Field<ListGraphType<ApplicationType>>(nameof(ActiveJobOfferDto.Applications));
            Field<JobOfferType>(nameof(ActiveJobOfferDto.JobOffer));
        }
    }
}
