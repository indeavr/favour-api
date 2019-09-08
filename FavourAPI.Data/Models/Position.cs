using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class Position
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IList<IndustryPosition> IndustryPositions { get; set; }

        public virtual IList<PositionSkill> PositionSkills { get; set; }

        public virtual Consumer Consumer { get; set; }
    }
}
