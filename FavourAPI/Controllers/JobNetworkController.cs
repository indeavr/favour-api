using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using FavourAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobNetworkController : ControllerBase
    {
        private readonly ISkillService skillService;
        private readonly IPositionService positionService;
        private readonly IIndustryService industryService;

        public JobNetworkController(ISkillService skillService, IPositionService positionService, IIndustryService industryService)
        {
            this.skillService = skillService;
            this.positionService = positionService;
            this.industryService = industryService;
        }

        [HttpGet("skills")]
        public async Task<ActionResult<SkillDto[]>> GetSkills()
        {
            return Ok(this.skillService.GetSkills().Data);
        }

        [HttpGet("positions")]
        public async Task<ActionResult<PositionDto[]>> GetPositions()
        {
            return Ok(this.positionService.GetPositions().Data);
        }

        [HttpGet("industries")]
        public async Task<ActionResult<IndustryDto[]>> GetIndustries()
        {
            return Ok(this.industryService.GetAll().Data);
        }
    }
}