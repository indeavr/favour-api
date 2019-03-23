using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IConsumerService
    {
        bool AddOrUpdateConsumer(string userId, ConsumerDto consumerData);
    }
}
