using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class Position
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual IList<IndustryPosition> IndustryPositions { get; set; }

        public virtual IList<PositionSkills> PositionSkills { get; set; }
    }
}
