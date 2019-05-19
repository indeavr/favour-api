using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class PositionDto
    {
        public IndustryDto Industry { get; set; }

        public SkillDto Skills { get; set; }
    }
}
