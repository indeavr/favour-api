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

        public virtual Provider Provider { get; set; } // TODO: make another model or add virtual prop for Consumer aswell
    }
}
