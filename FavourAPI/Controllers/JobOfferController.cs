using FavourAPI.Dtos;
using FavourAPI.Services;
using FavourAPI.Services.Dtos;
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
        private readonly IOfferService offerService;
        public JobOfferController([FromServices] IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [AllowAnonymous]
        [HttpGet("application")]
        public async Task<ActionResult> SeedApplication()
        {
            var jobOfferId = Guid.NewGuid().ToString();
            var consumerId = Guid.NewGuid().ToString();

            var application = new ApplicationDto()
            {
                Message = "Plis mnogo iskam da te vzemesh",
                Time = 124152141242131
            };

            this.offerService.AddApplication(consumerId, jobOfferId, application);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AddOffer([FromQuery] string userId, [FromBody] JobOfferDto jobOffer)
        {
            this.offerService.AddJobOffer(userId, jobOffer);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<JobOfferDto>>> Get(
            [FromQuery] string userId,
            [FromQuery] string currentPosition,
            [FromQuery] string chunkSize,
            [FromQuery] long accessTime,
            [FromQuery] JobSearchFiltersDto filters)
        {
            var jobList = offerService.GetAllOffers();
            // Sort first

            var chunk = jobList.Skip(int.Parse(currentPosition)).Take(int.Parse(chunkSize)).ToList();

            return Ok(chunk);
        }
    }
}
