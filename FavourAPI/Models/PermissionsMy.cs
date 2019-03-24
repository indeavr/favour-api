using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class PermissionMy
    {
        [ForeignKey("User")]
        public string Id { get; set; }

        public bool HasSufficientInfoConsumer { get; set; }

        public bool HasSufficientInfoProvider { get; set; }

        public bool CanApplyConsumer { get; set; }

        public virtual User User { get; set; }
    }
}
