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
    }
}
