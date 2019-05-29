using FavourAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class JobSearchFiltersDto
    {
        [FromQuery(Name ="keyword")]
        public string Keyword { get; set; }

        [FromQuery(Name = "location")]
        public string Location { get; set; }

        [FromQuery(Name = "shifts")]
        public List<PeriodDto> Shifts { get; set; }

        [FromQuery(Name = "positions")]
        public List<PositionDto> Positions { get; set; }
    }
}
