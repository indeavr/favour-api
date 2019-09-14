using AutoMapper;
using FavourAPI.Data;
using FavourAPI.GraphQL;
using FavourAPI.Services;
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
