using AutoMapper;
using FavourAPI.ApiModels;
using FavourAPI.Dtos;
using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<CompanyProvider, CompanyProviderDto>();
            CreateMap<CompanyProviderDto, CompanyProvider>()
                .ForMember(dto => dto.FoundedYear, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.FoundedYear)));

            CreateMap<PersonProvider, PersonProviderDto>();
            CreateMap<PersonProviderDto, PersonProvider>();

            CreateMap<OfficeDto, Office>();
            CreateMap<Office, OfficeDto>();

            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();

            CreateMap<Email, EmailDto>();
            CreateMap<EmailDto, Email>();

            CreateMap<PhoneNumber, PhoneNumberDto>();
            CreateMap<PhoneNumberDto, PhoneNumber>();

            CreateMap<Industry, IndustryDto>();
            CreateMap<IndustryDto, Industry>();

            CreateMap<Position, PositionDto>();
            CreateMap<PositionDto, Position>();


        }
    }
}
