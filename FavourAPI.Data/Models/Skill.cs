using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class Skill
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IList<PositionSkills> PositionSkills { get; set; }

        public virtual Consumer Consumer { get; set; }
    }
}
