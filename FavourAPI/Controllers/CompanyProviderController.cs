using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FavourAPI.Services;
using System.Threading.Tasks;
using FavourAPI.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class CompanyProviderController : ControllerBase
    {
        private readonly ICompanyConsumerService companyProviderService;
        private readonly IUserService userService;
        private readonly IOfficeService officeService;
        private readonly IIndustryService industryService;

        public CompanyProviderController(
            [FromServices] ICompanyConsumerService cps,
            [FromServices] IUserService userService,
            [FromServices] IOfficeService officeService,
            [FromServices] IIndustryService industryService)
        {
            this.companyProviderService = cps;
            this.userService = userService;
            this.officeService = officeService;
            this.industryService = industryService;
        }

        [HttpGet]
        public async Task<ActionResult<CompanyConsumer>> GetCompanyProvider([FromQuery] string userId, [FromQuery]bool withPhoto)
        {
            var companyProvider = await this.companyProviderService.GetById(userId, withPhoto);
            return Ok(companyProvider);
        }

        //[HttpPut]
        //public async Task<ActionResult> AddCompanyProvider([FromQuery] string userId, [FromBody] CompanyProviderDto companyProvider)
        //{
        //    await this.companyProviderService.AddCompanyProvider(userId, companyProvider);
        //    await this.userService.UpdatePermissions(userId, (p) => p.HasSufficientInfoProvider = true);
        //    var companyProviderResult = await this.companyProviderService.GetProvider(userId, false);

        //    return Ok(companyProviderResult);
        //}

        [HttpGet("office")]
        public async Task<ActionResult<OfficeDto>> GetOffices([FromQuery] string userId)
        {
            var offices = this.officeService.GetOffices();
            return Ok(offices);
        }

        [HttpPut("office")]
        public async Task<ActionResult> AddOffice([FromQuery] string userId, [FromBody] OfficeDto office)
        {
            await this.officeService.AddOffice(userId, office);

            return Ok();
        }

        [HttpGet("profilePhoto")]
        public async Task<ActionResult<string>> GetProfilePhoto([FromQuery] string userId)
        {
            return Ok(await this.companyProviderService.GetProfilePhoto(userId));
        }

        [HttpGet("viewTimes")]
        public async Task<ActionResult<ConsumerViewTimeDto>> GetViewTimes([FromQuery] string userId)
        {
            return Ok(this.companyProviderService.GetViewTime(userId));
        }

        [HttpPost("viewTimes")]
        public async Task<ActionResult> AddOrUpdateViewTimes([FromQuery] string userId, [FromBody] ConsumerViewTimeDto viewTimeDto)
        {
            await this.companyProviderService.AddOrUpdateViewTime(userId, viewTimeDto);
            return Ok();
        }
    }
}