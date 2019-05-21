using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class PositionSkills
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid PositionId { get; set; }

        public virtual Position Position { get; set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid SkillId { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
