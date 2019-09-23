using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class EmailInputType : InputObjectGraphType<EmailDto>
    {
        public EmailInputType()
        {
            Field(e => e.Label);
            Field(e => e.EmailAddress);
        }
    }
}
