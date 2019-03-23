using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class CompanyProviderDto
    {
        public string Name { get; set; }

        public IndustryDto[] Industries { get; set; }

        public PositionDto[] TargetedPositions { get; set; }

        public long FoundedYear { get; set; }

        public byte[] Picture { get; set; }

        public string Description { get; set; }

        public int NumberOfEmployees { get; set; }

        public OfficeDto[] Offices { get; set; }
    }
}
