using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class PeriodDto
    {
        public string Id { get; set; }

        public long StartDate { get; set; }

        public long EndDate { get; set; }

        public long StartHour { get; set; }

        public long EndHour { get; set; }
    }
}
