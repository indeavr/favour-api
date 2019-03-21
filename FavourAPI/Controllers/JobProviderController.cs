using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobProviderController : ControllerBase
    {
        private readonly IJobProviderService jobProviderService;

        public JobProviderController([FromServices]IJobProviderService jobProviderService)
        {
            this.jobProviderService = jobProviderService;
        }

        [HttpGet("{id}")]
        public IActionResult GetJobProvider(string id)
        {
            var jobProvider = this.jobProviderService.GetProviderByUserId(id);

            return Ok(jobProvider);
        }

        [HttpPut]
        public IActionResult AddJobProvider([FromBody] JobProviderDto providerDto)
        {
            this.jobProviderService.AddJobProviderForUser(providerDto);

            return Ok();
        }
    }
}