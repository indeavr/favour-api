using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models.enums
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
    }
}
