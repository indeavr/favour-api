using System;
using System.Linq;
using FavourAPI.Dtos;
using AutoMapper;
using FavourAPI.Data.Models;
using FavourAPI.Data;

namespace FavourAPI.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public ConsumerService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // Add for now
        public bool AddOrUpdateConsumer(string userId, ConsumerDto consumerData)
        {
            var currentUserInfo = GetConsumer(Guid.Parse(userId));

            var dbConsumer = mapper.Map<Consumer>(consumerData);
            var correctSexDb = this.dbContext.Sexes.First(s => s.Value == dbConsumer.Sex.Value);
            var correctSkills = this.dbContext.Skills.Where(s => dbConsumer.Skills.Any(dbcS => dbcS.Name == s.Name)).ToArray();
            dbConsumer.Sex = correctSexDb;
            dbConsumer.Skills = correctSkills;
            dbConsumer.Id = Guid.Parse(userId);

            var phoneNumberDb = this.dbContext.PhoneNumbers.FirstOrDefault(number => number.Label == consumerData.PhoneNumber);
            if (phoneNumberDb != null)
            {
                dbConsumer.PhoneNumber = phoneNumberDb;
            }

            Guid guidUserId = Guid.Parse(userId);
            var currentUser = this.dbContext.Users.SingleOrDefault(u => u.Id == guidUserId);
            currentUser.PermissionMy.HasSufficientInfoConsumer = true;

            dbContext.Consumers.Add(dbConsumer);

            dbContext.SaveChanges();
            return CheckForLoginProceedPermission(dbConsumer);
        }

        public ConsumerDto GetById(string userId)
        {
            Guid guidUserId = Guid.Parse(userId);
            var dto = this.mapper.Map<ConsumerDto>(GetConsumer(guidUserId));

            return dto;
        }

        private Consumer GetConsumer(Guid userId)
        {
            return dbContext.Consumers.SingleOrDefault(c => c.Id == userId);
        }

        public bool CheckForLoginProceedPermission(Consumer consumer)
        {
            return consumer.FirstName != null && consumer.LastName != null && consumer.PhoneNumber != null;
        }

        public void SaveJobOffer(string userId, string jobOfferId)
        {
            this.dbContext.ConsumerJobOffers.Add(new ConsumerJobOffer()
            {
                JobOfferId = Guid.Parse(jobOfferId),
                ConsumerId = Guid.Parse(userId)
            });

            this.dbContext.SaveChanges();
        }
    }
}
