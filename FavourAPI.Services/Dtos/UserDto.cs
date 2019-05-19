using FavourAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.ApiModels
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public PersonProviderDto PersonProvider { get; set; }

        public CompanyProviderDto CompanyProvider { get; set; }

        public PermissionsMyDto PermissionMy { get; set; }
    }
}
