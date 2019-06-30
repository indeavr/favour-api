using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models.Enums
{
    public enum ApplicationState
    {
        Pending,
        Accepted,
        Rejected
    }

    public class ApplicationStateDb
    {
        [Key]
        public string Value { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
