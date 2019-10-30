using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class PositionType : ObjectGraphType<PositionDto>
    {
        public PositionType()
        {
            Field(p => p.Name);
            Field<IntGraphType>(nameof(PositionDto.Order));
            Field<IndustryType>(nameof(PositionDto.Industry));
            Field<ListGraphType<SkillType>>(nameof(PositionDto.Skills));
        }
    }
}
