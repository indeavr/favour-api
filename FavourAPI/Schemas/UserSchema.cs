using FavourAPI.Mutations;
using FavourAPI.Queries;
using GraphQL;
using GraphQL.Types;

namespace FavourAPI.Schemas
{
    public class UserSchema : Schema
    {
        public UserSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
            Mutation = resolver.Resolve<UserMutation>();
        }
    }
}
