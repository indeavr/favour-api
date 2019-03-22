using FavourAPI.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class JobOffer
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Period> Periods { get; set; }

        public string Location { get; set; }

        public DateTime TimePosted { get; set; }

        public User User { get; set; }

        public decimal Money { get; set; }

        public ICollection<Application> Applications { get; set; }

        public ICollection<Skill> RequiredSkills { get; set; }

        public JobOfferStateDb State { get; set; }

        public virtual Consumer Consumer { get; set; }

        public string Review { get; set; }

        // tags
    }
}
