using FavourAPI.Dtos;
using System.Collections.Generic;

namespace FavourAPI.Dtos
{
    public class ConsumerDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public LocationDto Location { get; set; }

        public string Sex { get; set; }

        public string[] Skills { get; set; }

        public SavedJobOfferDto[] SavedJobOffers { get; set; }
        
        public List<string> DesiredPositions { get; set; }

        public CompletedJobOfferDto[] CompletedJobOffers { get; set; }

        public OngoingJobOfferDto[] OngoingJobOffers { get; set; }

        public ApplicationDto[] Applications { get; set; }

        public string ProfilePhoto { get; set; }

        public List<ExperienceDto> Experiences { get; set; }

        public List<EducationDto> Educations { get; set; }

        //public byte[] CV { get; set; }

        //public List<byte[]> Photos { get; set; }
    }
}
