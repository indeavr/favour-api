using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Dtos;
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
        private readonly IMapper autoMapper;

        public PositionService([FromServices] WorkFavourDbContext dbContext, IMapper autoMapper)
        {
            this.dbContext = dbContext;
            this.autoMapper = autoMapper;
        }
        public Result<PositionDto[]> GetPositions()
        {
            return new OkResult<PositionDto[]>(this.dbContext.Positions.Select(p => this.autoMapper.Map<PositionDto>(p)).ToArray());
        }
    }
}
