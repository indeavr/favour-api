﻿using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.Services.GraphQLTypes
{
    public class PositionType : ObjectGraphType<PositionDto>
    {
        public PositionType()
        {
            Field(p => p.Name);
            Field<IndustryType>(nameof(PositionDto.Industry));
            Field<ListGraphType<SkillType>>(nameof(PositionDto.Skills));
        }
    }
}
