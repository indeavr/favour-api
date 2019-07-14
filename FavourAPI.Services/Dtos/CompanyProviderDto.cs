using AutoMapper.Configuration.Annotations;
using System;

namespace FavourAPI.Dtos
{
    public class CompanyProviderDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IndustryDto[] Industries { get; set; }

        public PositionDto[] TargetedPositions { get; set; }

        public long FoundedYear { get; set; }

        [Ignore]
        public string ProfilePhoto { get; set; }

        public string Bulstat { get; set; }

        public string Description { get; set; }

        public int NumberOfEmployees { get; set; }

        public OfficeDto[] Offices { get; set; }
    }
}
