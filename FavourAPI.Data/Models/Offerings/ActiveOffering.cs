using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FavourAPI.Data.Models.Offerings
{
    public class ActiveOffering
    {
        [ForeignKey("Offering")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public virtual Offering Offering { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public bool IsDeleted { get; set; }
    }
}
