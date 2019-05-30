using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class IndustryPosition
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid IndustryId { get; set; }
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid PositionId { get; set; }

        public virtual Industry Industry { get; set; }
        public virtual Position Position { get; set; }
    }
}
