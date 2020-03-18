using System;
using System.Linq;
using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public class PersonConsumerService : IPersonConsumerService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public PersonConsumerService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddPersonConsumer(string userId, PersonConsumerDto personProvider)
        {
            var provider = this.mapper.Map<PersonConsumer>(personProvider);
            provider.Id = Guid.Parse(userId);

            this.dbContext.PersonConsumers.Add(provider);
            await this.dbContext.SaveChangesAsync();
        }

        public PersonConsumerDto GetPersonConsumer(string userId)
        {
            Guid guidUserId = Guid.Parse(userId);
            var provider = this.dbContext.PersonConsumers.SingleOrDefault(pp => pp.Id == guidUserId);

            return this.mapper.Map<PersonConsumerDto>(provider);
        }
    }
}
