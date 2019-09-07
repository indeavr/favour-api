using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FavourAPI.Data;
using FavourAPI.Data.Models;

namespace FavourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromServices] WorkFavourDbContext myService)
        {
            var headers = Request.Headers;
            //var user = myService.Users.First(u => u.Id == Guid.Parse("77BB5A96-9906-4135-61E0-08D6E15505CD"));
            //var permissionName = myService.PermissionNames.First(pn => pn.Name == "PermissionNameTest");
            //user.Permissions.Add(new Permission() { CurrentCount = 0, PermissionName = permissionName, PermissionNameId = permissionName.Name, User = user, UserId = user.Id });
            //myService.SaveChanges();
            //user.Permissions.Add(new Permission() { CurrentCount = 0, PermissionName = permissionName, PermissionNameId = permissionName.Name, User = user, UserId = user.Id });
            //myService.SaveChanges();
            return new UnauthorizedResult();

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            throw new Exception("gosho");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
