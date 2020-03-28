using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class PersonConsumerType : ObjectGraphType<PersonConsumerDto>
    {
        public PersonConsumerType()
        {
            Name = "PersonConsumerType";

            Field(c => c.Id);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field(c => c.PhoneNumber);
            //Field(c => c.ProfilePhoto);
            Field(c => c.Sex);

        }
    }
}
