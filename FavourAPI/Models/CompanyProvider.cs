using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class CompanyProvider
    {
        [ForeignKey("User")]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Industry> Industries { get; set; }

        public ICollection<Position> TargetedPositions { get; set; }

        public DateTime FoundedYear { get; set; }

        public byte[] Picture { get; set; }

        public string Description { get; set; }

        public int NumberOfEmployees { get; set; }

        public ICollection<Office> Offices { get; set; }

        public virtual User User { get; set; }
    }
}
