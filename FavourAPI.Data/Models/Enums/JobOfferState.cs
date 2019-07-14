using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models.Enums
{
    public enum JobOfferState
    {
        Active,
        Ongoing,
        Completed,
        Expired,
        Upcoming
    }

    public class JobOfferStateDb
    {
        [Key]
        public string Value { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
