using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FavourAPI.Helpers;
using Microsoft.Extensions.Options;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using FavourAPI.Data.Models;
using FavourAPI.Services;
using FavourAPI.Services.Helpers.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FavourAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UsersController(IEmailSender emailSender, [FromServices] IUserService userService, IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            //this.userRepo = userManager;
            this.emailSender = emailSender;
            this.userService = userService;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var headers = Request.Headers;
            await this.userService.Create("abv@abv", "mypassword");
            return new UnauthorizedResult();

            //return new string[] { "value1", "value2" };
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userDto)
        {
            UserDto user;
            try
            {
                user = this.userService.Authenticate(userDto.Email, userDto.Password);
            }
            catch (EmailAppException ex)
            {
                return BadRequest(new { message = $"Email custom exception: {ex}" });
            }
            catch (PasswordAppException ex)
            {
                return BadRequest(new { message = $"Password custom exception: {ex}" });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = $"App custom exception: {ex}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Exception: {ex}" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                UserId = user.Id,
                Email = user.Email,
                Token = tokenString,
                Permissions = user.PermissionMy,
                ExpiresAt = DateTime.UtcNow + TimeSpan.FromTicks(TimeSpan.TicksPerHour)
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            //var user = new User() { Email = userDto.Email, UserName = userDto.Email };
            //var result = await this.userManager.CreateAsync(user, userDto.Password);
            //if (result.Succeeded)
            //{
            //    string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
            //    //string callbackUrl = Url.Page(
            //    //    "/users/confirmEmail",
            //    //    pageHandler: null,
            //    //    values: new { userId = user.Id, code = code },
            //    //    protocol: Request.Scheme
            //    //    );

            //    string callbackUrl = $"https://localhost:44334/users/confirmEmail?userId={HttpUtility.UrlEncode(user.Id.ToString())}&code={HttpUtility.UrlEncode(code)}";

            //    await emailSender.SendEmailAsync(userDto.Email, "Confirm your email",
            //        $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.");
            //}

            ////var result = await this.userService.Create(user.Email, user.Password);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            //if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            //{
            //    ModelState.AddModelError("", "User Id and Code are required");
            //    return BadRequest(ModelState);
            //}
            ////var parsedCode = 

            //var user = this.userService.GetById(userId);
            //IdentityResult result = await this.userManager.ConfirmEmailAsync(user, code);

            return Ok();
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> Refresh([FromQuery] string oldToken, [FromQuery] string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Token = tokenString,
                ExpiresAt = DateTime.UtcNow + TimeSpan.FromTicks(TimeSpan.TicksPerHour)
            });
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = this.userService.GetAll();
        //    var userDtos = this.mapper.Map<IList<UserDto>>(users);
        //    return Ok(userDtos);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = this.userService.GetById(id);
            var userDto = this.mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserDto userDto)
        {
            // map dto to entity and set id
            var user = this.mapper.Map<User>(userDto);
            var idGuid = Guid.Parse(id);
            user.Id = idGuid;

            try
            {
                // save 
                await this.userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.userService.Delete(id);

            return Ok();
        }
    }
}
