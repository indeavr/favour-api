using AutoMapper;
using FavourAPI.ApiModels;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Data.Models.Enums;

namespace FavourAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<CompanyProvider, CompanyProviderDto>()
                .ForMember(db => db.ProfilePhoto, opt => opt.Ignore())
                .ForMember(dto => dto.ActiveJobOffers, opt => opt.MapFrom(db => db.Offers.Where(o => o.ActiveState != null).Select(o => o.ActiveState).ToArray()))
                .ForMember(dto => dto.CompletedJobOffers, opt => opt.MapFrom(db => db.Offers.Where(o => o.CompletedState != null).Select(o => o.CompletedState).ToArray()))
                .ForMember(dto => dto.OngoingJobOffers, opt => opt.MapFrom(db => db.Offers
                .Where(o => o.OngoingState != null && o.OngoingState.Count > 0)
                .Select(o => o.OngoingState)
                .ToArray()));

            CreateMap<CompanyProviderDto, CompanyProvider>()
                .ForMember(dto => dto.FoundedYear, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.FoundedYear)))
                .ForMember(dto => dto.ProfilePhoto, opt => opt.Ignore());

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

            CreateMap<Position, PositionDto>().ForMember(dto => dto.Skills, opt => opt.MapFrom(db => db.PositionSkills));
            CreateMap<PositionDto, Position>();

            CreateMap<Industry, IndustryDto>().ForMember(dto => dto.Positions, opt => opt.MapFrom(db => db.IndustryPositions));
            CreateMap<IndustryDto, Industry>();

            CreateMap<IList<IndustryPosition>, PositionDto[]>().ConstructUsing((ips, rc) => ips.Select(ip => rc.Mapper.Map<PositionDto>(ip.Position)).ToArray());
            CreateMap<IList<PositionSkill>, SkillDto[]>().ConstructUsing((pss, rc) => pss.Select(ps => rc.Mapper.Map<SkillDto>(ps.Skill)).ToArray());


            CreateMap<CompletionResult, CompletionResultDto>();
            CreateMap<CompletionResultDto, CompletionResult>();

            CreateMap<Consumer, ConsumerDto>()
                .ForMember(cdto => cdto.PhoneNumber, opt => opt.MapFrom(c => c.PhoneNumber.Number))
                .ForMember(cdto => cdto.Sex, opt => opt.MapFrom(c => c.Sex.Value))
                .ForMember(cdto => cdto.Skills, opt => opt.MapFrom(c => c.Skills.Select(s => s.Name)))
                .ForMember(cdto => cdto.ProfilePhoto, opt => opt.Ignore());

            Func<ConsumerDto, Consumer, object> transformSex = (cdto, _) =>
              {
                  Enum.Parse<Sex>(cdto.Sex);
                  return new SexDb() { Value = cdto.Sex };
              };

            CreateMap<ConsumerDto, Consumer>()
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(cdto => new PhoneNumber() { Number = cdto.PhoneNumber }))
                .ForMember(c => c.Sex, opt => opt.MapFrom(transformSex))
                .ForMember(c => c.Skills, opt => opt.MapFrom(cdto => cdto.Skills.Select(s => new Skill() { Name = s })))
                 .ForMember(c => c.ProfilePhoto, opt => opt.Ignore());


            CreateMap<JobOffer, JobOfferDto>();
            CreateMap<JobOfferDto, JobOffer>();

            CreateMap<PermissionMy, PermissionsMyDto>();
            CreateMap<PermissionsMyDto, PermissionMy>();

            CreateMap<PeriodDto, Period>();
            //.ForMember(dto => dto.EndDate, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.EndDate)))
            //.ForMember(dto => dto.EndHour, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.EndHour)))
            //.ForMember(dto => dto.StartDate, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.StartDate)))
            //.ForMember(dto => dto.StartHour, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.StartHour)));

            CreateMap<Period, PeriodDto>();
            //.ForMember(dto => dto.EndDate, opt => opt.MapFrom(pdb => pdb.EndDate.Millisecond))
            //.ForMember(dto => dto.EndHour, opt => opt.MapFrom(pdb => pdb.EndHour.Millisecond))
            //.ForMember(dto => dto.StartDate, opt => opt.MapFrom(pdb => pdb.StartDate.Millisecond))
            //.ForMember(dto => dto.StartHour, opt => opt.MapFrom(pdb => pdb.StartHour.Millisecond));

            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>();

            CreateMap<LocationDto, Location>();
            CreateMap<Location, LocationDto>();

            CreateMap<ProviderViewTime, ProviderViewTimeDto>();
            CreateMap<ProviderViewTimeDto, ProviderViewTime>();

            CreateMap<Education, EducationDto>();
            CreateMap<EducationDto, Education>();

            CreateMap<string, Position>().ConstructUsing(str => new Position() { Name = str });
            CreateMap<Position, string>().ConstructUsing(pos => pos.Name);

            CreateMap<Experience, ExperienceDto>();
            CreateMap<ExperienceDto, Experience>();

            CreateMap<FieldOfStudy, FieldOfStudyDto>();
            CreateMap<FieldOfStudyDto, FieldOfStudy>();

            CreateMap<OngoingJobOffer, OngoingJobOfferDto>();
            CreateMap<OngoingJobOfferDto, OngoingJobOffer>();

            CreateMap<OngoingJobOffer[], OngoingJobOfferDto>().ConstructUsing((offers, context) =>
            {
                return new OngoingJobOfferDto()
                {
                    Consumers = offers.Select(o => context.Mapper.Map<ConsumerDto>(o.Consumer)).ToArray(),
                    JobOffer = context.Mapper.Map<JobOfferDto>(offers.First().JobOffer)
                };
            });

            CreateMap<CompletedJobOfferDto, CompletedJobOffer>();
            CreateMap<CompletedJobOffer, CompletedJobOfferDto>();

            CreateMap<ActiveJobOffer, ActiveJobOfferDto>();
            CreateMap<ActiveJobOfferDto, ActiveJobOffer>();
        }
    }
}
