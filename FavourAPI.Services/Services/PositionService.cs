using FavourAPI.Data;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FavourAPI.Services.Services
{
    public class PositionService : IPositionService
    {
        private readonly WorkFavourDbContext dbContext;

        public PositionService([FromServices] WorkFavourDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Result<string[]> GetPositions()
        {
            return new CorrectResult<string[]>(this.dbContext.Positions.Select(p => p.Name).ToArray());
        }
    }
}
