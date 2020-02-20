using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace FavourAPI.Data.Factories
{
    public interface IClaimsFactory
    {
        Claim CreateAuthenticatedClaim();
    }
}
