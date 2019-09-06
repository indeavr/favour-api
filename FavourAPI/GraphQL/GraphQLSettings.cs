using Microsoft.AspNetCore.Http;
using System;

namespace FavourAPI
{
    public class GraphQLSettings
    {
        public PathString Path { get; set; } = "/graphql";

        public Func<HttpContext, object> BuildUserContext { get; set; }

        public bool EnableMetrics { get; set; }
    }
}