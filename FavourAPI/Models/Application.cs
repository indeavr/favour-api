using FavourAPI.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class Application
    {
        public string Id { get; set; }

        public DateTime Time { get; set; }

        public JobOffer JobOffer { get; set; }

        public Consumer Consumer { get; set; }

        public ApplicationStateDb State { get; set; }
    }
}
