using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class PermissionsType : ObjectGraphType<PermissionsMyDto>
    {
        public PermissionsType()
        {
            Field(e => e.SideChosen);
            Field(e => e.HasSufficientInfoProvider);
            Field(e => e.HasSufficientInfoConsumer);
            Field(e => e.CanApplyConsumer);
        }
    }
}
