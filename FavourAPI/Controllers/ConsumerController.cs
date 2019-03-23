using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FavourAPI.Dtos;

namespace FavourAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerService consumerService;

        public ConsumerController([FromServices] IConsumerService service)
        {
            this.consumerService = service;
        }

        [HttpGet]
        public ActionResult<ConsumerDto> GetConsumer([FromQuery] string userId)
        {
            // var consumer = this.consumerService.GetById(userId);
            return Ok(new
            {
                //consumer = consumer
            });
        }

        [HttpPost]
        public ActionResult<bool> AddConsumer([FromQuery]string userId, [FromBody] ConsumerDto consumer)
        {
            bool canProceed = this.consumerService.AddOrUpdateConsumer(userId, consumer);
            return Ok(new
            {
                canProceedAfterLogin = canProceed
            });
        }
    }
}