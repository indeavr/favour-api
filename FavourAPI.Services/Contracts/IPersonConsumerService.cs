using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IPersonConsumerService
    {
        Task<IEnumerable<PersonConsumerDto>> GetAll();

        Task<PersonConsumerDto> GetById(string userId, bool withPhoto = false);

        Task<PersonConsumerDto> AddPersonConsumer(string userId, PersonConsumerDto personConsumer);

        Task<string> GetProfilePhoto(string userId);

        ConsumerViewTimeDto GetViewTime(string userId);

        Task AddOrUpdateViewTime(string userId, ConsumerViewTimeDto viewTime);

        Task<List<ApplicationDto>> GetApplications(string userId);
    }
}
