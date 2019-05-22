using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;

namespace FavourAPI.Services
{
    public interface IConsumerService
    {
        bool AddOrUpdateConsumer(string userId, ConsumerDto consumerData);

        ConsumerDto GetById(string userId);

        bool CheckForLoginProceedPermission(Consumer consumer);

        void SaveJobOffer(string userId, string jobOfferId);
    }
}
