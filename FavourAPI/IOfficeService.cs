using FavourAPI.Dtos;
using FavourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public interface IOfficeService
    {
        IEnumerable<OfficeDto> GetOffices();

        void AddOffice(CompanyProvider provider, OfficeDto office);

        void AddOffice(string providerId, OfficeDto office);

        void AddIndustriesForOffice(Office dbModel);
    }
}
