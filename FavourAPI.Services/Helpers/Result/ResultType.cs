using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Result
{
    public enum ResultType
    {
        Ok,
        Invalid,
        Unauthorized,
        PermissionsDenied,
        NotFound
    }
}
