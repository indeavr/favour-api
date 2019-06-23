using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IConsumerService
    {
        Task<bool> AddOrUpdateConsumer(string userId, ConsumerDto consumerData);

        Task<ConsumerDto> GetById(string userId);

        bool CheckForLoginProceedPermission(Consumer consumer);

        void SaveJobOffer(string userId, string jobOfferId);
    }
}
