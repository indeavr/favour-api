using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using FavourAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonProviderController : ControllerBase
    {
        private readonly IPersonConsumerService personProviderService;
        public PersonProviderController([FromServices] IPersonConsumerService pps)
        {
            this.personProviderService = pps;
        }

        //[HttpGet]
        //public async Task<ActionResult<PersonProviderDto>> GetCompanyProvider([FromQuery] string userId)
        //{
        //    return Ok(this.personProviderService.GetPersonProvider(userId));
        //}

        [HttpPut]
        public async Task<ActionResult> AddPersonPrvider([FromQuery] string userId, [FromBody] PersonConsumerDto personProvider)
        {
            await this.personProviderService.AddPersonConsumer(userId, personProvider);
            return Ok();
        }
    }
}