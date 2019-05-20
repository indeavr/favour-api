using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class OfficeIndustry
    {
        [Key]
        public Guid OfficeId { get; set; }

        public virtual Office Office { get; set; }

        [Key]
        public Guid IndustryId { get; set; }

        public virtual Industry Industry { get; set; }
    }
}
