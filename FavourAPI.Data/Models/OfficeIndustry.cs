using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class OfficeIndustry
    {
        public string OfficeId { get; set; }
        public virtual Office Office { get; set; }

        public string IndustryId { get; set; }
        public virtual Industry Industry { get; set; }
    }
}
