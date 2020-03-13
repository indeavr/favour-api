using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services
{
    public interface IOfficeService
    {
        IEnumerable<OfficeDto> GetOffices();

        Task AddOffice(CompanyConsumer provider, OfficeDto office);

        Task AddOffice(string providerId, OfficeDto office);

        Task AddIndustriesForOffice(Office dbModel);
    }
}
