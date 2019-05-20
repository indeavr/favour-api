using FavourAPI.Dtos;
using System;

namespace FavourAPI.ApiModels
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PersonProviderDto PersonProvider { get; set; }

        public CompanyProviderDto CompanyProvider { get; set; }

        public PermissionsMyDto PermissionMy { get; set; }
    }
}
