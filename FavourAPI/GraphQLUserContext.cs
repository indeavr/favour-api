using System.Security.Claims;

namespace FavourAPI
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}