using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FavourAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeederController : Controller
    {
        private readonly IDatabaseSeeder databaseSeeder;

        public SeederController([FromServices] IDatabaseSeeder databaseSeeder)
        {
            this.databaseSeeder = databaseSeeder;
        }

        //[HttpPost("seed")]
        public IActionResult Index()
        {
            databaseSeeder.SeedData();

            return Ok("Dabase is seeded successfully!");
        }
    }
}