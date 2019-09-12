using System;

namespace FavourAPI.Dtos
{
    public class PeriodDto
    {
        public string Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }
    }
}
