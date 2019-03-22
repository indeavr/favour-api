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
            CreateMap<CompanyProviderDto, CompanyProvider>();

            CreateMap<PersonProvider, PersonProviderDto>();
            CreateMap<PersonProviderDto, PersonProvider>();
        }
    }
}
