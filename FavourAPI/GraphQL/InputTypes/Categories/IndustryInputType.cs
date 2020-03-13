using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class IndustryInputType : InputObjectGraphType<IndustryDto>
    {
        public IndustryInputType()
        {
            Field(i => i.Name);
        }
    }
}
