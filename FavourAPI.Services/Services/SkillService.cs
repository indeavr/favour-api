using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Dtos;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FavourAPI.Services.Services
{
    public class SkillService : ISkillService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper autoMapper;

        public SkillService([FromServices] WorkFavourDbContext dbContext, IMapper autoMapper)
        {
            this.dbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public Result<SkillDto[]> GetSkills()
        {
            return new OkResult<SkillDto[]>((dbContext.Skills.Select(s => autoMapper.Map<SkillDto>(s)).ToArray()));
        }
    }
}
