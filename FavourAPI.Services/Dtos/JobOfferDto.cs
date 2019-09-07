using FavourAPI.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace FavourAPI.Dtos
{
    public class JobOfferDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public double Money { get; set; }

        public string State { get; set; }

        public DateTime TimePosted { get; set; }

        public List<PeriodDto> Periods { get; set; }

        public string ProviderId { get; set; }

        public List<SkillDto> RequiredSkills { get; set; }
    }
}
