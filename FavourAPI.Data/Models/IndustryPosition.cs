using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class IndustryPosition
    {
        [Key]
        public Guid IndustryId { get; set; }

        public virtual Industry Industry { get; set; }

        [Key]
        public Guid PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
