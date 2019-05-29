using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class JobSearchFiltersDto
    {
        public string Keyword { get; set; }

        public string Location { get; set; }

        public List<PeriodDto> Shifts { get; set; }

        public List<PositionDto> Positions { get; set; }
    }
}
