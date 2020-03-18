using FavourAPI.Data.Dtos.Offerings;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class ActiveOfferingType : ObjectGraphType<ActiveOfferingDto>
    {
        public ActiveOfferingType()
        {
            Field(ajo => ajo.Id);
            Field(jo => jo.Applications, nullable: true, type: typeof(ListGraphType<ApplicationType>));
            Field(jo => jo.Offering, nullable: false, type: typeof(NonNullGraphType<OfferingType>));
        }
    }
}
