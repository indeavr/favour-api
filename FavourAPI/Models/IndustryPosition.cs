using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class IndustryPosition
    {
        public string IndustryId { get; set; }
        public virtual Industry Industry { get; set; }

        public string PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
