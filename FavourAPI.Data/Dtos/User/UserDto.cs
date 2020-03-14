using FavourAPI.Dtos;
using System;

namespace FavourAPI.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneConfirmed { get; set; }

        public string Password { get; set; }

        public PersonConsumerDto PersonConsumer { get; set; }

        public CompanyConsumerDto CompanyConsumer { get; set; }

        public ProviderDto Provider { get; set; }

        public PermissionsMyDto PermissionMy { get; set; }
    }
}
