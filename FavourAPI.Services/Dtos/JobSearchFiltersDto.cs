using FavourAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Dtos
{
    public class JobSearchQueryDto
    {
        [FromQuery(Name = "accessTime")]
        public long AcessTime { get; set; }

        [FromQuery(Name = "currentPosition")]
        public string CurrentPosition { get; set; }

        [FromQuery(Name = "chunkSize")]
        public string ChunkSize { get; set; }

        [FromQuery(Name ="keyword")]
        public string Keyword { get; set; }

        [FromQuery(Name = "location")]
        public string Location { get; set; }

        [FromQuery(Name = "shifts")]
        public List<PeriodDto> Shifts { get; set; }

        [FromQuery(Name = "positions")]
        public List<string> Positions { get; set; }
    }
}
