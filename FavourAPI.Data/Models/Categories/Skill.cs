using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class Skill
    {
        [Key]
        public string Name { get; set; }

        public virtual IList<PositionSkill> PositionSkills { get; set; }

        public virtual Provider Consumer { get; set; }
    }
}
