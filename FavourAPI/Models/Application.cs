using FavourAPI.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class Application
    {
        [Key]
        public string Id { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        public virtual Consumer Consumer { get; set; }

        public virtual ApplicationStateDb State { get; set; }
    }
}
