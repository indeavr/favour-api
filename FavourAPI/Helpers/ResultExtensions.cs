using FavourAPI.Services.Helpers.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Helpers
{
    public static class ResultExtensions
    {
        public static ActionResult FromResult<T>(this ControllerBase controller, Result<T> result)
        {
            switch (result.Type)
            {
                case ResultType.Ok:
                    return controller.Ok(result.Data);
                case ResultType.NotFound:
                    return controller.NotFound(result.Errors);
                case ResultType.Invalid:
                    return controller.BadRequest(result.Errors);
                case ResultType.Unauthorized:
                    return controller.Unauthorized();
                default:
                    throw new Exception("An unhandled result has occurred from a service call.");
            }
        }
    }
}
