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
using FavourAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FavourAPI
{
    // [Authorize]     
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUserService userService;
        private IMapper mapper;
        private readonly AppSettings appSettings;

        public UsersController([FromServices] IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var headers = Request.Headers;
            this.userService.Create(new UserDto() { Id = "user123", Email = "abv@abv", Password = "abv" }, "abv");
            return new UnauthorizedResult();

            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        //// PUT api/<controller>/5
        //[HttpPut]
        //public string Put(int id, [FromBody]UserDto value)
        //{
        //    this.userService.Add(new User(value.Email, value.Password));
        //    var result = this.userService.Authenticate(value.Email, value.Password);

        //    return result.Token;
        //}


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = this.userService.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

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
                Id = user.Id,
                Email = user.Email,
                Token = tokenString,
                Permissions = user.PermissionMy
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            try
            {
                // save 
                this.userService.Create(userDto, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = this.userService.GetAll();
        //    var userDtos = this.mapper.Map<IList<UserDto>>(users);
        //    return Ok(userDtos);
        //}

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = this.userService.GetById(id);
            var userDto = this.mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var user = this.mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                // save 
                this.userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.userService.Delete(id);
            return Ok();
        }
    }
}
