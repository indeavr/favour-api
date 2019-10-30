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
            Field<IntGraphType>(nameof(IndustryDto.Order));
            Field<ListGraphType<PositionType>>(nameof(IndustryDto.Positions));
        }
    }
}
