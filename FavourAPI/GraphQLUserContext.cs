using FavourAPI.Data.Repositories;
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
        public IUserRepository UserRepo { get; }

        public GraphQLUserContext(HttpContext httpContext)
        {
            RequestServices = httpContext.RequestServices;
            UserRepo = httpContext.RequestServices.GetRequiredService<IUserRepository>();
        }
    }
}