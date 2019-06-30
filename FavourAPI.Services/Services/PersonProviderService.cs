using System;
using System.Linq;
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
            provider.Id = Guid.Parse(userId);

            this.dbContext.PersonProviders.Add(provider);
            this.dbContext.SaveChanges();
        }

        public PersonProviderDto GetPersonProvider(string userId)
        {
            Guid guidUserId = Guid.Parse(userId);
            var provider = this.dbContext.PersonProviders.SingleOrDefault(pp => pp.Id == guidUserId);

            return this.mapper.Map<PersonProviderDto>(provider);
        }
    }
}
