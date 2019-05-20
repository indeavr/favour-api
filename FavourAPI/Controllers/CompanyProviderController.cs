using System;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FavourAPI.Services;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    // [Authorize]
    [ApiController]
    public class CompanyProviderController : ControllerBase
    {
        private readonly ICompanyProviderService companyProviderService;
        private readonly IUserService userService;
        private readonly IOfficeService officeService;

        public CompanyProviderController(
            [FromServices] ICompanyProviderService cps,
            [FromServices] IUserService userService,
            [FromServices] IOfficeService officeService)
        {
            this.companyProviderService = cps;
            this.userService = userService;
            this.officeService = officeService;
        }

        [HttpGet]
        public ActionResult<CompanyProvider> GetCompanyProvider([FromQuery] Guid userId)
        {
            this.companyProviderService.AddCompanyProvider(Guid.NewGuid(), new CompanyProviderDto()
            {
                Id = Guid.NewGuid(),
                Description = "neshto si",
                FoundedYear = new DateTime().Ticks,
                Name = "Macuranka",
                NumberOfEmployees = 100,
                Offices = new OfficeDto[]
                {
                    new OfficeDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = "MyOffice",
                        Location = "Sofia",
                        Industries = new IndustryDto[]
                        {
                            new IndustryDto()
                            {
                                Name = "BaiGoshoIndustriqta"
                            }
                        }
                    }

                },
                Industries = new IndustryDto[]
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
        public ActionResult AddCompanyProvider([FromQuery] Guid userId, [FromBody] CompanyProviderDto companyProvider)
        {
            this.companyProviderService.AddCompanyProvider(userId, companyProvider);
            this.userService.UpdatePermissions(userId, (p) => p.HasSufficientInfoProvider = true);
            var companyProviderResult = this.companyProviderService.GetProvider(userId);

            return Ok(companyProviderResult);
        }

        [HttpGet("office")]
        public ActionResult<OfficeDto> GetOffices([FromQuery] Guid userId)
        {
            var offices = this.officeService.GetOffices();
            return Ok(offices);
        }

        [HttpPut("office")]
        public ActionResult AddOffice([FromQuery] Guid userId, [FromBody] OfficeDto office)
        {
            this.officeService.AddOffice(userId, office);

            return Ok();
        }
    }
}