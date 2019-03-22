using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class Skill
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual Position Position { get; set; } 

        public virtual Consumer Consumer { get; set; }
    }
}
