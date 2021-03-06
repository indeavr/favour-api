using FavourAPI.Dtos;
using FavourAPI.GraphQL;
using FavourAPI.Services;
using FavourAPI.Services.GraphQLInputTypes;
using GraphQL.Types;

namespace FavourAPI.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IUserService userService)
        {
            Field<UserType>("createHuman",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<UserDto>("user");

                    return userService.Create(user.Email, user.Password, "", "");
                });
        }
    }
}
