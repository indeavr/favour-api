using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Dtos;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers.Result;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FavourAPI.Services.Services
{
    public class IndustryService : IIndustryService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper autoMapper;

        public IndustryService([FromServices] WorkFavourDbContext dbContext, IMapper autoMapper)
        {
            this.dbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public Result<IndustryDto[]> GetAll()
        {
            return new OkResult<IndustryDto[]>(this.dbContext.Industries.ToList().Select(i => this.autoMapper.Map<IndustryDto>(i)).ToArray());
        }
    }
}
