using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class Period
    {
        public string Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }

        public virtual JobOffer JobOffer { get; set; }
    }
}
