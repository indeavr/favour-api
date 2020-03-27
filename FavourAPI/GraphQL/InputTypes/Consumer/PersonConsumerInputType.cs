using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class PersonConsumerInputType : InputObjectGraphType<PersonConsumerDto>
    {
        public PersonConsumerInputType()
        {
            Name = "PersonConsumerInput";

            Field(c => c.Description);
            Field(c => c.Sex);
            Field(c => c.PhoneNumber, nullable: true, type: typeof(NonNullGraphType<StringGraphType>));
        }
    }
}
