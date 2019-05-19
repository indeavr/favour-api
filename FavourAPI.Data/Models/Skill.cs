using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class Skill
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual IList<PositionSkills> PositionSkills { get; set; }

        public virtual Consumer Consumer { get; set; }
    }
}
