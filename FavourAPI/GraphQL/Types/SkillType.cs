using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class SkillType : ObjectGraphType<SkillDto>
    {
        public SkillType()
        {
            Field(s => s.Name);
        }
    }
}
