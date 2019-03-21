using AutoMapper;
using FavourAPI.Dtos;
using FavourAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public class JobProviderService : IJobProviderService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public JobProviderService([FromServices]WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public JobProvider GetProviderByUserId(string id)
        {
            return this.dbContext.JobProviders.Single(jp => jp.Id == id);
        }

        public void AddJobProviderForUser(JobProviderDto jobProvider)
        {
            var dbModelProvider = this.mapper.Map<JobProvider>(jobProvider);

            this.dbContext.JobProviders.Add(dbModelProvider);
            this.dbContext.SaveChanges();
        }

    }
}
