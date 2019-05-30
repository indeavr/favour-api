using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class OfficeIndustry
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid OfficeId { get; set; }
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid IndustryId { get; set; }

        public virtual Office Office { get; set; }
        public virtual Industry Industry { get; set; }
    }
}
