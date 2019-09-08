using FavourAPI.Data.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace FavourAPI
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }

        public IServiceProvider RequestServices { get; }
        public IUserRepo UserRepo { get; }

        public GraphQLUserContext(HttpContext httpContext)
        {
            RequestServices = httpContext.RequestServices;
            UserRepo = httpContext.RequestServices.GetRequiredService<IUserRepo>();
        }
    }
}