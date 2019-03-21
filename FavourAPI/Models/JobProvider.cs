using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class JobProvider
    {
        [ForeignKey("User")]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }

        public virtual User User { get; set; }

    }
}
