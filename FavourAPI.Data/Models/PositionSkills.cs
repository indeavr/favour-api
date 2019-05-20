using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class PositionSkills
    {
        [Key]
        public Guid PositionId { get; set; }

        public virtual Position Position { get; set; }

        public Guid SkillId { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
