using System;

namespace FavourAPI.Dtos
{
    public class PeriodDto
    {
        public string Id { get; set; }

        public DateTime StartTime { get; set; } // The aggregation of StartDate + StartHour

        public DateTime EndTime { get; set; } // The aggregation of EndDate + EndHour

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan StartHour { get; set; }

        public TimeSpan EndHour { get; set; }
    }
}
