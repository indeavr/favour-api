using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Authorization;

namespace FavourAPI.GraphQL.Types
{
    public class SkillType : ObjectGraphType<SkillDto>
    {
        public SkillType()
        {
            this.AuthorizeWith("UserPolicy");
            Field(s => s.Name);
        }
    }
}
