using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class ExperienceDto
    {
        public string Id { get; set; }

        public string Position { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool CurrentlyWorking { get; set; }

        public ConsumerDto Consumer { get; set; }
    }
}
