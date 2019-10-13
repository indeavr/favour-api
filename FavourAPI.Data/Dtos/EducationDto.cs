using FavourAPI.Data.Dtos;
using System;

namespace FavourAPI.Dtos
{
    public class EducationDto
    {
        public string Id { get; set; }

        public FieldOfStudyDto Field { get; set; }

        public UniversityDto University { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
