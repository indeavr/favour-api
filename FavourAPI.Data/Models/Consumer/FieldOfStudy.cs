using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class FieldOfStudy
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
