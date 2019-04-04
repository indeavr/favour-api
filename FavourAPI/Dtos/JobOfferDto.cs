using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class JobOfferDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public double Money { get; set; }

        public long TimePosted { get; set; }

        public List<PeriodDto> Periods { get; set; }

        public CompanyProviderDto Provider { get; set; }

        public List<SkillDto> RequiredSkills { get; set; }
    }
}
