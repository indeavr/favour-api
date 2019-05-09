using FavourAPI.Dtos;
using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IConsumerService
    {
        bool AddOrUpdateConsumer(string userId, ConsumerDto consumerData);

        ConsumerDto GetById(string userId);

        bool CheckForLoginProceedPermission(Consumer consumer);

        void SaveJobOffer(string userId, string jobOfferId);
    }
}
