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
        private readonly IOfferService offerService;
        public JobOfferController([FromServices] IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [AllowAnonymous]
        [HttpGet("seed")]
        public ActionResult SeedOffer()
        {
            var periods = new List<PeriodDto>()
            {
                new PeriodDto()
                {
                    Id= "period",
                    StartDate =20123100000,
                    EndDate=20123100000,
                    StartHour =20123100000,
                    EndHour =20123100000,
                }
            };

            var requiredSkills = new List<SkillDto>()
            {
                new SkillDto()
                {
                    Name = "Da pliushti",
                },
                 new SkillDto()
                {
                    Name = "Da pulni",
                }
            };

            var jobOffer = new JobOfferDto()
            {
                Id = "jobOffer123",
                Description = "adsadass",
                Location = "Sofia",
                Money = 3000,
                Title = "Anakondioto",
                TimePosted = 20123100000,
                Periods = periods,
                RequiredSkills = requiredSkills
            };

            this.offerService.AddJobOffer("user123", jobOffer);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("application")]
        public ActionResult SeedApplication()
        {
            var jobOfferId = "jobOffer123";
            var consumerId = "user123";

            var application = new ApplicationDto()
            {
                Message = "Plis mnogo iskam da te vzemesh",
                Time = 124152141242131
            };

            this.offerService.AddApplication(consumerId, jobOfferId, application);

            return Ok();
        }

        [HttpPut]
        public ActionResult AddOffer([FromQuery]string userId, [FromBody] JobOfferDto jobOffer)
        {
            this.offerService.AddJobOffer(userId, jobOffer);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<JobOfferDto>> Get(
            [FromQuery]string userId,
            [FromQuery]string currentPosition,
            [FromQuery]string chunkSize,
            [FromQuery]long accessTime)
        {
            var jobList = offerService.GetAllOffers();
            // Sort first

            var chunk = jobList.Skip(int.Parse(currentPosition)).Take(int.Parse(chunkSize)).ToList();

            return Ok(chunk);
        }
    }
}
