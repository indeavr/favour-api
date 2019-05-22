using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public interface IOfficeService
    {
        IEnumerable<OfficeDto> GetOffices();

        void AddOffice(CompanyProvider provider, OfficeDto office);

        void AddOffice(string providerId, OfficeDto office);

        void AddIndustriesForOffice(Office dbModel);
    }
}
