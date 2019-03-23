using FavourAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    [Authorize]
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
            this.offerService.AddJobOffer(companyProvider);
            return Ok();
        }
    }
}
