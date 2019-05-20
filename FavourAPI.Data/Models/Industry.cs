using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class Industry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Name { get; set; }

        public virtual IList<IndustryPosition> IndustryPositions { get; set; }

        public virtual IList<OfficeIndustry> OfficeIndustries { get; set; }
    }
}
