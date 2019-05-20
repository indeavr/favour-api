using System;

namespace FavourAPI.Dtos
{
    public class IndustryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public PositionDto[] Positions { get; set; }
    }
}
