﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using FavourAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    // [Authorize]
    [ApiController]
    public class CompanyProviderController : ControllerBase
    {
        private readonly ICompanyProviderService companyProviderService;
        private readonly IUserService userService;
        public CompanyProviderController([FromServices] ICompanyProviderService cps, [FromServices] IUserService userService)
        {
            this.companyProviderService = cps;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<CompanyProvider> GetCompanyProvider([FromQuery]string userId)
        {
            this.companyProviderService.AddCompanyProvider("user123", new CompanyProviderDto()
            {
                Id = "user123",
                Description = "neshto si",
                FoundedYear = new DateTime().Ticks,
                Name = "Macuranka",
                NumberOfEmployees = 100,
                Offices = new OfficeDto[]
                {
                    new OfficeDto(){
                        Id="office1",
                        Name="MyOffice",
                        Location="Sofia",
                        Industries = new IndustryDto[]
                        {
                            new IndustryDto()
                            {
                                Name = "BaiGoshoIndustriqta"
                            }
                        }
                    }
                    
                },
                Industries =  new IndustryDto[]
                {
                    new IndustryDto()
                    {
                        Name="PetHeaven"
                    }
                }
            });
            return Ok(this.companyProviderService.GetProvider(userId));
        }

        [HttpPut]
        public ActionResult AddCompanyProvider([FromQuery]string userId, [FromBody] CompanyProviderDto companyProvider)
        {
            this.companyProviderService.AddCompanyProvider(userId, companyProvider);
            this.userService.UpdatePermissions(userId, (p) => p.HasSufficientInfoProvider = true);
            return Ok();
        }
    }
}