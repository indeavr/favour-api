using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using FavourAPI.Services;
using FavourAPI.Services.Contracts;

namespace FavourAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerService consumerService;
        private readonly ISkillService skillService;
        private readonly IPositionService positionService;

        public ConsumerController([FromServices] IConsumerService service, [FromServices] ISkillService skillService, [FromServices] IPositionService positionService)
        {
            this.consumerService = service;
            this.skillService = skillService;
            this.positionService = positionService;
        }

        [HttpGet]
        public async Task<ActionResult<ConsumerDto>> GetConsumer([FromQuery] string userId, [FromQuery] bool withPhoto)
        {
            var consumer = await this.consumerService.GetById(userId, withPhoto);

            return Ok(consumer);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddConsumer([FromQuery] string userId, [FromBody] ConsumerDto consumer)
        {
            ConsumerDto newConsumer = await this.consumerService.AddOrUpdateConsumer(userId, consumer);

            return Ok(newConsumer);
        }

        [HttpPost("save")]
        public async Task<ActionResult> SaveJobOffer([FromQuery] string userId, [FromQuery] string jobOfferId)
        {
            this.consumerService.SaveJobOffer(userId, jobOfferId);

            return Ok();
        }

        [HttpGet("skills")]
        public async Task<ActionResult<string[]>> GetSkills()
        {
            return Ok(this.skillService.GetSkills().Data);
        }

        [HttpGet("positions")]
        public async Task<ActionResult<string[]>> GetPositions()
        {
            return Ok(this.positionService.GetPositions().Data);
        }

        [HttpGet("profilePhoto")]
        public async Task<ActionResult<string>> GetProfilePhoto([FromQuery] string userId)
        {
            return Ok(await this.consumerService.GetProfilePhoto(userId));
        }
    }
}