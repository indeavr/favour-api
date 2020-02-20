using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace FavourAPI.Data.Factories
{
    public class ClaimsFactory : IClaimsFactory
    {
        public Claim CreateAuthenticatedClaim()
        {
            return new Claim("role", "User");
        }
    }
}
