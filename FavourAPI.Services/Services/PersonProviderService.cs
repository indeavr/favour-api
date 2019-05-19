using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;

namespace FavourAPI.Services
{
    public class PersonProviderService : IPersonProviderService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public PersonProviderService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddPersonProvider(string userId, PersonProviderDto personProvider)
        {
            var provider = this.mapper.Map<PersonProvider>(personProvider);
            provider.Id = userId;

            this.dbContext.PersonProviders.Add(provider);
            this.dbContext.SaveChanges();
        }

        public PersonProviderDto GetPersonProvider(string userId)
        {
            var provider = this.dbContext.PersonProviders.SingleOrDefault(pp => pp.Id == userId);

            return this.mapper.Map<PersonProviderDto>(provider);
        }
    }
}
