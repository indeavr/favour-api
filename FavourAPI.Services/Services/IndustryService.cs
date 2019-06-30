using FavourAPI.Data;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers.Result;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FavourAPI.Services.Services
{
    public class IndustryService : IIndustryService
    {
        private readonly WorkFavourDbContext dbContext;

        public IndustryService([FromServices] WorkFavourDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Result<string[]> GetAll()
        {
            return new OkResult<string[]>(this.dbContext.Industries.Select(i => i.Name).ToArray());
        }
    }
}
