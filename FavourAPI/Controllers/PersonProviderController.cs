﻿using System;
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
    public class PersonProviderController : ControllerBase
    {
        private readonly IPersonProviderService personProviderService;
        public PersonProviderController([FromServices] IPersonProviderService pps)
        {
            this.personProviderService = pps;
        }

        [HttpGet("{userId}")]
        public ActionResult<PersonProviderDto> GetCompanyProvider(string userId)
        {
            return Ok(this.personProviderService.GetPersonProvider(userId));
        }

        [HttpPut("{userId}")]
        public ActionResult AddPersonPrvider(string userId, [FromBody] PersonProviderDto personProvider)
        {
            this.personProviderService.AddPersonProvider(userId, personProvider);
            return Ok();
        }
    }
}