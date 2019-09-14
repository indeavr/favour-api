using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class IndustryType : ObjectGraphType<IndustryDto>
    {
        public IndustryType()
        {
            Field(i => i.Name);
            Field<PositionType>(nameof(IndustryDto.Positions));
        }
    }
}
