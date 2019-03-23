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

        public ActionResult<ConsumerDto> GetConsumer()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<bool> AddConsumer([FromQuery]string userId, ConsumerDto consumer)
        {
            bool canProceed = this.consumerService.AddOrUpdateConsumer(userId, consumer);
            return Ok(new
            {
                canProceedAfterLogin = canProceed
            });
        }
    }
}