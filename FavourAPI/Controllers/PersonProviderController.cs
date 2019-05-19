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
        private readonly IPersonProviderService personProviderService;
        public PersonProviderController([FromServices] IPersonProviderService pps)
        {
            this.personProviderService = pps;
        }

        [HttpGet]
        public ActionResult<PersonProviderDto> GetCompanyProvider([FromQuery]string userId)
        {
            return Ok(this.personProviderService.GetPersonProvider(userId));
        }

        [HttpPut]
        public ActionResult AddPersonPrvider([FromQuery]string userId, [FromBody] PersonProviderDto personProvider)
        {
            this.personProviderService.AddPersonProvider(userId, personProvider);
            return Ok();
        }
    }
}