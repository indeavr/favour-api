﻿using FavourAPI.Models.enums;
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

        public virtual ICollection<Period> Periods { get; set; }

        public string Location { get; set; }

        public DateTime TimePosted { get; set; }

        public virtual User User { get; set; }

        public double Money { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual  ICollection<Skill> RequiredSkills { get; set; }

        public virtual JobOfferStateDb State { get; set; }

        public virtual Consumer Consumer { get; set; }

        public string Review { get; set; }
    }
}
