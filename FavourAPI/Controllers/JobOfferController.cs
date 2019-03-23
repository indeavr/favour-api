using FavourAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferService jobOfferService;

        public JobOfferController([FromServices] IJobOfferService service)
        {
            this.jobOfferService = service;
        }

        [HttpGet]
        public ActionResult<JobOfferDto> Get()
        {
            var jobList = jobOfferService.
            return Ok();
        }
    }
}
