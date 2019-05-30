using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class PermissionMy
    {
        [ForeignKey("User")]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public bool HasSufficientInfoConsumer { get; set; }
        public bool HasSufficientInfoProvider { get; set; }
        public bool CanApplyConsumer { get; set; }

        public virtual User User { get; set; }
    }
}
