using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Dtos
{
    public class AuthDto
    {
        public string Token { get; set; }

        public string UserId { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneConfirmed { get; set; }

        public string FullName { get; set; }

        public string LastAccountSide { get; set; }

        public PermissionsMyDto Permissions { get; set; }
    }
}
