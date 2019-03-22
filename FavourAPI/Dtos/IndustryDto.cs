using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class IndustryDto
    {
        public string Name { get; set; }

        public PositionDto[] Positions { get; set; }
    }
}
