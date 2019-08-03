using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class Education
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual FieldOfStudy Field { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
