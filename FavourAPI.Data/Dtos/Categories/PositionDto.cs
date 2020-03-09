namespace FavourAPI.Dtos
{
    public class PositionDto
    {
        public string Name { get; set; }

        public IndustryDto Industry { get; set; }

        public int? Order { get; set; }

        public SkillDto[] Skills { get; set; }
    }
}
