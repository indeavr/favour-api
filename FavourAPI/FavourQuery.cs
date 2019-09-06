using AutoMapper;
using FavourAPI.ApiModels;
using FavourAPI.Data;
using FavourAPI.Services;
using FavourAPI.Services.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public class FavourQuery : ObjectGraphType
    {
        public FavourQuery(IUserService userService, IMapper mapper)
        {
            Field<ListGraphType<UserType>>("users", arguments: new QueryArguments(new QueryArgument<IdGraphType>()
            {
                Name = "id"
            }),
            resolve: context =>
            {
                var userId = context.GetArgument<string>("id");
                if (userId != null)
                {
                    return mapper.Map<UserDto>(userService.GetById(userId));

                }

                return userService.GetAll();

            });
        }
    }
}
