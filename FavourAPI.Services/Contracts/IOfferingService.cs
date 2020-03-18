using FavourAPI.Data.Dtos.Favour;
using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Services.Contracts
{
    public interface IOfferingService
    {
        Task<OfferingDto> AddOffering(string Guid, OfferingDto offering);

        Task<OfferingDto> GetById(string favourId);

        Task<List<OfferingDto>> GetAllActiveOfferings();

        Task AddApplication(string providerId, string favourId, ApplicationDto application);

        Task ConfirmApplication(string applicationId, List<PeriodDto> finalPeriodsDto);

        Task Reject(string applicationId);
    }
}
