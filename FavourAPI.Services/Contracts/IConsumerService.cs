using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public interface IConsumerService
    {
        Task<ConsumerDto> AddConsumer(string userId, ConsumerDto consumer);

        Task<ConsumerDto> AddOrUpdateConsumer(string userId, ConsumerDto consumerData);

        Task<ConsumerDto> GetById(string userId);

        Task<ConsumerDto> GetById(string userId, bool withPhoto);

        Task<IEnumerable<ConsumerDto>> GetAll();

        bool CheckForLoginProceedPermission(Consumer consumer);

        Task SaveJobOffer(string userId, string jobOfferId);

        Task<string> GetProfilePhoto(string userId);
    }
}
