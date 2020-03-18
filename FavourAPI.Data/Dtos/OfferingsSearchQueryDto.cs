using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Data.Dtos
{
    public class OfferingsSearchQueryDto
    {
        public long AcessTime { get; set; }

        public string CurrentPosition { get; set; }

        public string ChunkSize { get; set; }

        public string Keyword { get; set; }

        // TODO: v2 - city/country/adress what is this
        //public string Location { get; set; }

        public List<PeriodDto> Dates { get; set; }

        // TODO: rename it to categories / sub-categories ? - discuss
        public List<string> Positions { get; set; }
    }
}
