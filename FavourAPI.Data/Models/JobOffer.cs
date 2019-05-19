using FavourAPI.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models
{
    public class JobOffer
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public string Location { get; set; }

        public DateTime TimePosted { get; set; }

        //[ForeignKey("User")]
        //public string ProviderId {get; set;}

        public virtual CompanyProvider Provider { get; set; }

        public double Money { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual ICollection<Skill> RequiredSkills { get; set; }

        public virtual JobOfferStateDb State { get; set; }
        
        public virtual CompletionResult Result { get;set; }

        public virtual ICollection<ConsumerJobOffer> ConsumerJobOffers { get; set; }
    }
}
        