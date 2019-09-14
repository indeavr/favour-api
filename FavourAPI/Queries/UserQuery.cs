using AutoMapper;
using FavourAPI.GraphQL;
using FavourAPI.Services;
using GraphQL.Types;

namespace FavourAPI.Queries
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IUserService userService, IMapper mapper)
        {
            Field<ListGraphType<UserType>>("users", arguments: new QueryArguments(),
            resolve: context =>
            {
                return userService.GetAll();
            });

            Field<ObjectGraphType<UserType>>("user", arguments: new QueryArguments(new QueryArgument<IdGraphType>()
            {
                Name = "id"
            }),
            resolve: context =>
            {
                var userId = context.GetArgument<string>("id");
                return userService.GetById(userId);
            });
        }
    }
}
