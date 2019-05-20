using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;

namespace FavourAPI.Services
{
    public interface IConsumerService
    {
        bool AddOrUpdateConsumer(Guid userId, ConsumerDto consumerData);

        ConsumerDto GetById(Guid userId);

        bool CheckForLoginProceedPermission(Consumer consumer);

        void SaveJobOffer(Guid userId, Guid jobOfferId);
    }
}
