using FavourAPI.Dtos;
using System;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IPersonConsumerService
    {
        PersonConsumerDto GetPersonConsumer(string userId);

        Task AddPersonConsumer(string userId, PersonConsumerDto personConsumer);
    }
}
