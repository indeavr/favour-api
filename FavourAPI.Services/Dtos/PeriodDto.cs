using System;

namespace FavourAPI.Dtos
{
    public class PeriodDto
    {
        public Guid Id { get; set; }

        public long StartDate { get; set; }

        public long EndDate { get; set; }

        public long StartHour { get; set; }

        public long EndHour { get; set; }
    }
}
