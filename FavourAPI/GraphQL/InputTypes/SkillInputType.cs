using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class SkillInputType : InputObjectGraphType<SkillDto>
    {
        public SkillInputType()
        {
            Field(s => s.Name);
        }
    }
}
