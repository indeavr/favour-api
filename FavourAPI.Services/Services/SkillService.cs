using FavourAPI.Data;
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

        public SkillService([FromServices] WorkFavourDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Result<string[]> GetSkills()
        {
            return new CorrectResult<string[]>((dbContext.Skills.Select(s => s.Name).ToArray()));
        }
    }
}
