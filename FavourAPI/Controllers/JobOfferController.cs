using FavourAPI.Dtos;
using FavourAPI.Services;
using FavourAPI.Services.Contracts;
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
        private readonly IApplicationService applicationService;

        public JobOfferController([FromServices] IOfferService offerService, [FromServices] IApplicationService applicationService)
        {
            this.offerService = offerService;
            this.applicationService = applicationService;
        }

        [HttpPut]
        public async Task<ActionResult> AddOffer([FromQuery] string userId, [FromBody] JobOfferDto jobOffer)
        {
            var newOfferResult = await this.offerService.AddJobOffer(userId, jobOffer);
            return Ok(newOfferResult);
        }

        [HttpPut("acceptApplication")]
        public async Task<ActionResult> AcceptApplication([FromQuery] string userId, [FromQuery] string applicationId)
        {
            var result = await this.applicationService.Accept(applicationId);

            return Ok(result);
        }

        [HttpPut("rejectApplication")]
        public async Task<ActionResult> RejectApplication([FromQuery] string userId, [FromQuery] string applicationId)
        {
            var result = await this.applicationService.Reject(applicationId);

            return Ok(result);
        }

        [HttpPut("confirmJobOffer")]
        public async Task<ActionResult> ConfirmJobOffer([FromQuery] string userId, [FromQuery] string jobOfferId)
        {
            var result = await this.applicationService.ConfirmJobOffer(jobOfferId);

            return Ok(result);
        }

        [HttpPut("apply")]
        public async Task<ActionResult> Apply([FromQuery] string userId, [FromQuery] string jobOfferId, [FromBody] ApplicationDto application)
        {
            var result = await this.applicationService.Apply(userId, jobOfferId, application.Message, application.Time);

            return Ok(result);
        }

        [HttpGet("applications")]
        public async Task<ActionResult> GetApplications([FromQuery] string userId, [FromQuery] string jobOfferId)
        {
            var result = this.applicationService.Get(jobOfferId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<JobOfferDto>>> Get(
            [FromQuery] string userId,
            [FromQuery] JobSearchQueryDto query)
        {
            var jobList = offerService.GetAllOffers();
            // Sort first

            var chunk = jobList
                .Skip(int.Parse(query.CurrentPosition))
                .Where((job) =>
                {
                    if (query.Positions == null || query.Positions.Count == 0)
                    {
                        return true;
                    }
                    return query.Positions.Contains(job.Title);
                })
                .Take(int.Parse(query.ChunkSize))
                .ToList();

            return Ok(chunk);
        }
    }
}
