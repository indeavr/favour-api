using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class JobSearchQueryDto
    {
        public long AcessTime { get; set; }

        public string CurrentPosition { get; set; }

        public string ChunkSize { get; set; }

        public string Keyword { get; set; }

        public string Location { get; set; }

        public List<PeriodDto> Shifts { get; set; }

        public List<string> Positions { get; set; }
    }
}
