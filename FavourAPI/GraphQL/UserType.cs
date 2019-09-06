using FavourAPI.Data.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Email);
            Field(u => u.EmailConfirmed);
            Field(u => u.Id, type: typeof(IdGraphType)).Description("Id of the User");
        }
    }

    public class FavourQuery : ObjectGraphType
    {
        public FavourQuery()
        {
            Field<UserType>(
                "user",
                resolve: context => new User() { Email = "firsty", EmailConfirmed = true, Id = Guid.Parse("d2626f94-9d9d-4fea-961b-d4b3f2ee388b") }
            );
        }
    }
}
