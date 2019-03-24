using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class PeriodDto
    {
        public long StartDate { get; set; }

        public long EndDate { get; set; }

        public long StartTime { get; set; }

        public long EndTime { get; set; }
    }
}
