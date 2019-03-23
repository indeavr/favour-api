using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using AutoMapper;
using FavourAPI.Models;

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
            var currentUserInfo = this.dbContext.Consumers.SingleOrDefault((c) => c.Id == userId);

            var dbConsumer = mapper.Map<Consumer>(consumerData);
            dbConsumer.Id = userId;
            //if (currentUserInfo == null)
            //{
            dbContext.Consumers.Add(dbConsumer);

            dbContext.SaveChanges();
            return CheckForLoginProceedPermission(dbConsumer);
            //}
        }

        public bool CheckForLoginProceedPermission(Consumer consumer)
        {
            return consumer.FirstName != null && consumer.LastName != null && consumer.PhoneNumber != null;
        }
    }
}
