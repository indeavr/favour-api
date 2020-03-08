using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models
{
    public class ActiveFavour
    {
        [ForeignKey("Favour")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Favour Favour { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
