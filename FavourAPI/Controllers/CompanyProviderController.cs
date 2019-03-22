using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using FavourAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyProviderController : ControllerBase
    {
        private readonly ICompanyProviderService companyProviderService;
        public CompanyProviderController([FromServices] ICompanyProviderService cps)
        {
            this.companyProviderService = cps;
        }

        [HttpGet("{userId}")]
        public ActionResult<CompanyProvider> GetCompanyProvider(string userId)
        {
            return Ok(this.companyProviderService.GetProvider(userId));
        }

        [HttpPut("{userId}")]
        public ActionResult AddCompanyProvider(string userId, [FromBody] CompanyProviderDto companyProvider)
        {
            this.companyProviderService.AddCompanyProvider(userId, companyProvider);
            return Ok();
        }
    }
}