using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Data.Dtos.Favour
{
    public class FavourDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public LocationDto Location { get; set; }

        public double Money { get; set; }

        public string State { get; set; }

        //public DateTime TimePosted { get; set; }

        //public List<PeriodDto> Periods { get; set; }

        //public PersonProviderDto Provider { get; set; }

        //public List<SkillDto> RequiredSkills { get; set; }
    }
}
