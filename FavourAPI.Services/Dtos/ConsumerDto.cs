using AutoMapper.Configuration.Annotations;
using FavourAPI.Data.Models;
using FavourAPI.Services.Dtos;
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

        public List<string> Skills { get; set; }

        public List<JobOfferDto> SavedJobOffers { get; set; }

        public List<CompletionResultDto> CompletedJobs { get; set; }

        public List<ApplicationDto> Applications { get; set; }

        public string ProfilePhoto { get; set; }

        public List<ExperienceDto> Experiences { get; set; }

        public List<EducationDto> Educations { get; set; }

        //public byte[] CV { get; set; }

        //public List<byte[]> Photos { get; set; }
    }
}
