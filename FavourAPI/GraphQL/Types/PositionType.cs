using FavourAPI.Data.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class PositionType: ObjectGraphType<Position>
    {
        public PositionType()
        {
            Field(s => s.Name);
            Field(
                name: "Consumer",
                type: typeof(ConsumerType)
            );
        }
    }
}
