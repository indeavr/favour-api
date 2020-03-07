using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class Experience
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual Position Position { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool CurrentlyWorking { get; set; }

        public virtual Consumer Consumer { get; set; }
    }
}
