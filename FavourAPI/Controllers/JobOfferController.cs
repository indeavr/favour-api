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

        [HttpPut]
        public ActionResult AddOffer([FromQuery]string userId, [FromBody] JobOfferDto companyProvider)
        {
            this.offerService.AddJobOffer(userId, companyProvider);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<JobOfferDto>> Get()
        {
            var jobList = offerService.GetAllOffers();
            

            return Ok(jobList);
        }
    }
}
