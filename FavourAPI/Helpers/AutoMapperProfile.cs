using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using FavourAPI.Data.Models.Enums;
using FavourAPI.Data.Dtos.Favour;

namespace FavourAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(user => user.Permissions, opt => opt.MapFrom(db => db.PermissionMy))
                .PreserveReferences();
            CreateMap<UserDto, User>().PreserveReferences();

            CreateMap<CompanyConsumer, CompanyConsumerDto>()
             .ForMember(db => db.ProfilePhoto, opt => opt.Ignore())
            .ForMember(dto => dto.ActiveJobOffers, opt => opt.MapFrom(db => db.Offers.Where(o => o.ActiveState != null).Select(o => o.ActiveState).ToArray()))
            .ForMember(dto => dto.CompletedJobOffers, opt => opt.MapFrom(db => db.Offers.Where(o => o.CompletedState != null).Select(o => o.CompletedState).ToArray()))
            .ForMember(dto => dto.OngoingJobOffers, opt => opt.MapFrom(db => db.Offers
            .Where(o => o.OngoingState != null && o.OngoingState.Count > 0)
            .Select(o => o.OngoingState)
            .ToArray())).PreserveReferences();

            CreateMap<CompanyConsumerDto, CompanyConsumer>()
                .ForMember(dto => dto.FoundedYear, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.FoundedYear)))
                .ForMember(dto => dto.ProfilePhoto, opt => opt.Ignore()).PreserveReferences();

            Func<PersonConsumerDto, PersonConsumer, object> transformSexConsumer = (cdto, _) =>
            {
                Enum.Parse<Sex>(cdto.Sex);
                return new SexDb() { Value = cdto.Sex };
            };

            CreateMap<PersonConsumer, PersonConsumerDto>()
                .ForMember(cdto => cdto.Sex, opt => opt.MapFrom(c => c.Sex.Value))
                .ForMember(cdto => cdto.FirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(cdto => cdto.LastName, opt => opt.MapFrom(c => c.User.LastName))
                .PreserveReferences();

            CreateMap<PersonConsumerDto, PersonConsumer>()
                .ForMember(c => c.Sex, opt => opt.MapFrom(transformSexConsumer))
                .PreserveReferences();

            CreateMap<OfficeDto, Office>().PreserveReferences();
            CreateMap<Office, OfficeDto>().PreserveReferences();

            CreateMap<Skill, SkillDto>().PreserveReferences();
            CreateMap<SkillDto, Skill>().PreserveReferences();

            CreateMap<Email, EmailDto>().PreserveReferences();
            CreateMap<EmailDto, Email>().PreserveReferences();

            CreateMap<PhoneNumber, PhoneNumberDto>().PreserveReferences();
            CreateMap<PhoneNumberDto, PhoneNumber>().PreserveReferences();

            CreateMap<Position, PositionDto>().ForMember(dto => dto.Skills, opt => opt.MapFrom(db => db.PositionSkills)).PreserveReferences();
            CreateMap<PositionDto, Position>().PreserveReferences();

            CreateMap<Industry, IndustryDto>().ForMember(dto => dto.Positions, opt => opt.MapFrom(db => db.IndustryPositions)).PreserveReferences();
            CreateMap<IndustryDto, Industry>().PreserveReferences();

            CreateMap<IList<IndustryPosition>, PositionDto[]>().ConstructUsing((ips, rc) => ips.Select(ip => rc.Mapper.Map<PositionDto>(ip.Position)).ToArray()).PreserveReferences();
            CreateMap<IList<PositionSkill>, SkillDto[]>().ConstructUsing((pss, rc) => pss.Select(ps => rc.Mapper.Map<SkillDto>(ps.Skill)).ToArray()).PreserveReferences();

            CreateMap<CompletionResult, CompletionResultDto>().PreserveReferences();
            CreateMap<CompletionResultDto, CompletionResult>().PreserveReferences();

            CreateMap<Provider, ProviderDto>()
                .ForMember(cdto => cdto.PhoneNumber, opt => opt.MapFrom(c => c.PhoneNumber.Number))
                .ForMember(cdto => cdto.Sex, opt => opt.MapFrom(c => c.Sex.Value))
                .ForMember(cdto => cdto.FirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(cdto => cdto.LastName, opt => opt.MapFrom(c => c.User.LastName))
                .ForMember(cdto => cdto.Skills, opt => opt.MapFrom(c => c.Skills.Select(s => s.Name).ToArray()))
                .ForMember(cdto => cdto.ProfilePhoto, opt => opt.Ignore())
                // must be fixed
                //.ForMember(cdto => cdto.OngoingJobOffers, opt => opt.MapFrom(db => db.OngoingJobOffers.ToArray()))
                .ForMember(cdto => cdto.SavedJobOffers, opt => opt.Ignore())
                .ForMember(cdto => cdto.Applications, opt => opt.Ignore())
                .ForMember(cdto => cdto.CompletedJobOffers, opt => opt.Ignore()).PreserveReferences();

            Func<ProviderDto, Provider, object> transformSex = (cdto, _) =>
              {
                  Enum.Parse<Sex>(cdto.Sex);
                  return new SexDb() { Value = cdto.Sex };
              };

            CreateMap<ProviderDto, Provider>()
                .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(cdto => new PhoneNumber() { Number = cdto.PhoneNumber }))
                .ForMember(c => c.Sex, opt => opt.MapFrom(transformSex))
                //.ForMember(c => c.ProfilePhoto, opt => opt.Ignore())
                .ForMember(c => c.Skills, opt => opt.MapFrom(cdto => cdto.Skills.Select(s => new Skill() { Name = s })))
                .PreserveReferences();


            CreateMap<JobOffer, JobOfferDto>().PreserveReferences();
            CreateMap<JobOfferDto, JobOffer>().PreserveReferences();

            CreateMap<Favour, FavourDto>().PreserveReferences();
            CreateMap<FavourDto, Favour>().PreserveReferences();

            CreateMap<Offering, OfferingDto>().PreserveReferences();
            CreateMap<OfferingDto, Offering>().PreserveReferences();

            CreateMap<PermissionMy, PermissionsMyDto>().PreserveReferences();
            CreateMap<PermissionsMyDto, PermissionMy>().PreserveReferences();

            CreateMap<PeriodDto, Period>().PreserveReferences();
            //.ForMember(dto => dto.EndDate, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.EndDate)))
            //.ForMember(dto => dto.EndHour, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.EndHour)))
            //.ForMember(dto => dto.StartDate, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.StartDate)))
            //.ForMember(dto => dto.StartHour, opt => opt.MapFrom(cpDto => new DateTime(TimeSpan.TicksPerMillisecond * cpDto.StartHour)));

            CreateMap<Period, PeriodDto>().PreserveReferences();
            //.ForMember(dto => dto.EndDate, opt => opt.MapFrom(pdb => pdb.EndDate.Millisecond))
            //.ForMember(dto => dto.EndHour, opt => opt.MapFrom(pdb => pdb.EndHour.Millisecond))
            //.ForMember(dto => dto.StartDate, opt => opt.MapFrom(pdb => pdb.StartDate.Millisecond))
            //.ForMember(dto => dto.StartHour, opt => opt.MapFrom(pdb => pdb.StartHour.Millisecond));

            CreateMap<ApplicationDto, Application>().PreserveReferences();
            CreateMap<Application, ApplicationDto>().PreserveReferences();

            CreateMap<LocationDto, Location>()
                //.ForMember(lDto => lDto.MapsId, opt => opt.MapFrom(l => l.Id))
                .PreserveReferences();
            CreateMap<Location, LocationDto>()
                //.ForMember(l => l.Id, opt => opt.MapFrom(l => l.MapsId))
                .PreserveReferences();

            CreateMap<ConsumerViewTime, ConsumerViewTimeDto>().PreserveReferences();
            CreateMap<ConsumerViewTimeDto, ConsumerViewTime>().PreserveReferences();

            CreateMap<Education, EducationDto>().PreserveReferences();
            CreateMap<EducationDto, Education>().PreserveReferences();

            CreateMap<string, Position>().ConstructUsing(str => new Position() { Name = str }).PreserveReferences();
            CreateMap<Position, string>().ConstructUsing(pos => pos.Name).PreserveReferences();

            CreateMap<Experience, ExperienceDto>().PreserveReferences();
            CreateMap<ExperienceDto, Experience>().PreserveReferences();

            CreateMap<FieldOfStudy, FieldOfStudyDto>().PreserveReferences();
            CreateMap<FieldOfStudyDto, FieldOfStudy>().PreserveReferences();

            //CreateMap<OngoingJobOffer, OngoingJobOfferDto>().ConstructUsing((ojo, contextResolver) =>
            //{
            //    return new OngoingJobOfferDto()
            //    {
            //        Consumers =  contextResolver.
            //        JobOffer = contextResolver.Mapper.Map<JobOfferDto>(ojo.JobOffer),
            //        IsDeleted = ojo.IsDeleted
            //    };
            //}).PreserveReferences();

            CreateMap<OngoingJobOffer[], OngoingJobOfferDto[]>().ConstructUsing((ojos, contextResolver) =>
            {
                var groups = ojos.GroupBy(ojo => ojo.JobOffer);

                var result = new List<OngoingJobOfferDto>();
                foreach (var group in groups)
                {
                    result.Add(new OngoingJobOfferDto()
                    {
                        Providers = group.Select(g => contextResolver.Mapper.Map<ProviderDto>(g.PersonConsumer)).ToArray(),
                        IsDeleted = group.Key.OngoingState.First().IsDeleted,
                        JobOffer = contextResolver.Mapper.Map<JobOfferDto>(group.Key)
                    });
                }

                return result.ToArray();
            }).PreserveReferences();


            CreateMap<CompletedJobOfferDto, CompletedJobOffer>().PreserveReferences();
            CreateMap<CompletedJobOffer, CompletedJobOfferDto>().PreserveReferences();

            CreateMap<ActiveJobOffer, ActiveJobOfferDto>().PreserveReferences();
            CreateMap<ActiveJobOfferDto, ActiveJobOffer>().PreserveReferences();

            CreateMap<ActiveFavour, ActiveFavourDto>().PreserveReferences();
            CreateMap<ActiveFavourDto, ActiveFavour>().PreserveReferences();
        }
    }
}
