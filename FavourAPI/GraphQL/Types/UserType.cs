using FavourAPI.Data.Models;
using FavourAPI.Data.Repos;
using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL
{
    public class UserType : ObjectGraphType<UserDto>
    {
        public UserType()
        {
            Field(u => u.Email);
            Field(u => u.EmailConfirmed);
            Field(u => u.Id, type: typeof(IdGraphType)).Description("Id of the User");
        }
    }
}
