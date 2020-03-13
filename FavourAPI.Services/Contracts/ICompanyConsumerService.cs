using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface ICompanyConsumerService
    {
        Task<IEnumerable<CompanyConsumerDto>> GetAll();

        Task<CompanyConsumerDto> GetConsumer(string userId, bool withPhoto);

        Task<CompanyConsumerDto> AddCompanyConsumer(string userId, CompanyConsumerDto companyConsumer);

        Task<string> GetProfilePhoto(string userId);

        ConsumerViewTimeDto GetViewTime(string userId);

        Task AddOrUpdateViewTime(string userId, ConsumerViewTimeDto viewTime);
    }
}
