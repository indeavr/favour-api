using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class PositionSkills
    {
        public string PositionId { get; set; }
        public virtual Position Position { get; set; }

        public string SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
