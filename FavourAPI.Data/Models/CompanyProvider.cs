using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class CompanyProvider
    {
        [ForeignKey("User")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Industry> Industries { get; set; }

        public virtual ICollection<Position> TargetedPositions { get; set; }

        public DateTime FoundedYear { get; set; }

        public byte[] Picture { get; set; }

        public string Description { get; set; }

        public int NumberOfEmployees { get; set; }

        public virtual ICollection<Office> Offices { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<JobOffer> Offers { get; set; }
    }
}
