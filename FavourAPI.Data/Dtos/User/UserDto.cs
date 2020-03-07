using FavourAPI.Dtos;
using System;

namespace FavourAPI.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneConfirmed { get; set; }

        public string Password { get; set; }

        public PersonProviderDto PersonProvider { get; set; }

        public CompanyProviderDto CompanyProvider { get; set; }

        public ConsumerDto Consumer { get; set; }

        public PermissionsMyDto PermissionMy { get; set; }
    }
}
