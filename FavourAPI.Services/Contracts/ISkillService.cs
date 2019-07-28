using FavourAPI.Dtos;
using FavourAPI.Services.Helpers.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Contracts
{
    public interface ISkillService
    {
        Result<SkillDto[]> GetSkills();
    }
}
