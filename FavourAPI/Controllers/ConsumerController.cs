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
        public ActionResult<ConsumerDto> GetConsumer([FromQuery] string userId)
        {
            var consumer = this.consumerService.GetById(userId);
            //this.consumerService.AddOrUpdateConsumer("user123", new ConsumerDto()
            //{
            //    FirstName = "gosho",
            //    LastName = "peshov",
            //    Location = "sofia",
            //    Sex = new Models.SexDb() { Value = nameof(Sex.Male) },
            //    PhoneNumber = "1234",
            //    Skills = new List<Skill>()
            //    {
            //        new Skill()
            //        {
            //            Id="skill1",
            //            Name = "Qm",
            //        }
            //    }
            //});
            return Ok(consumer);
        }

        [HttpPost]
        public ActionResult<bool> AddConsumer([FromQuery] string userId, [FromBody] ConsumerDto consumer)
        {
            bool canProceed = this.consumerService.AddOrUpdateConsumer(userId, consumer);

            return Ok(new
            {
                HasSufficientInfo = canProceed
            });
        }

        [HttpPost("save")]
        public ActionResult SaveJobOffer([FromQuery] string userId, [FromQuery] string jobOfferId)
        {
            this.consumerService.SaveJobOffer(userId, jobOfferId);

            return Ok();
        }

        [HttpGet("skills")]
        public ActionResult<string[]> GetSkills()
        {
            return Ok(this.skillService.GetSkills().Data);
        }

        [HttpGet("positions")]
        public ActionResult<string[]> GetPossitions()
        {
            return Ok(this.positionService.GetPositions().Data);
        }
    }
}