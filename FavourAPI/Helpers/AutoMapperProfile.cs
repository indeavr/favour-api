﻿using AutoMapper;
using FavourAPI.ApiModels;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Data.Models.Enums;
using FavourAPI.Services.Dtos;

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

            CreateMap<Consumer, ConsumerDto>()
                .ForMember(cdto => cdto.PhoneNumber, opt => opt.MapFrom(c => c.PhoneNumber.Number))
                .ForMember(cdto => cdto.Sex, opt => opt.MapFrom(c => c.Sex.Value))
                .ForMember(cdto => cdto.Skills, opt => opt.MapFrom(c => c.Skills.Select(s => s.Name)));

            Func<ConsumerDto, Consumer, object> transform = (cdto, _) =>
              {
                  Enum.Parse<Sex>(cdto.Sex);
                  return new SexDb() { Value = cdto.Sex };
              };

            CreateMap<ConsumerDto, Consumer>()
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(cdto => new PhoneNumber() { Number = cdto.PhoneNumber }))
                .ForMember(c => c.Sex, opt => opt.MapFrom(transform))
                .ForMember(c => c.Skills, opt => opt.MapFrom(cdto => cdto.Skills.Select(s => new Skill() { Name = s })));

            CreateMap<JobOffer, JobOfferDto>();
            CreateMap<JobOfferDto, JobOffer>();

            CreateMap<PermissionMy, PermissionsMyDto>();
            CreateMap<PermissionsMyDto, PermissionMy>();

            CreateMap<PeriodDto, Period>()
                .ForMember(dto => dto.EndDate, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.EndDate)))
                .ForMember(dto => dto.EndHour, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.EndHour)))
                .ForMember(dto => dto.StartDate, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.StartDate)))
                .ForMember(dto => dto.StartHour, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.StartHour)));

            CreateMap<Period, PeriodDto>()
                .ForMember(dto => dto.EndDate, opt => opt.MapFrom(pdb => pdb.EndDate.Millisecond))
                .ForMember(dto => dto.EndHour, opt => opt.MapFrom(pdb => pdb.EndHour.Millisecond))
                .ForMember(dto => dto.StartDate, opt => opt.MapFrom(pdb => pdb.StartDate.Millisecond))
                .ForMember(dto => dto.StartHour, opt => opt.MapFrom(pdb => pdb.StartHour.Millisecond));

            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>();

            CreateMap<LocationDto, Location>();
            CreateMap<Location, LocationDto>();
        }
    }
}
