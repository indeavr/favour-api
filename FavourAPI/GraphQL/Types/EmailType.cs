using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.GraphQL.Types
{
    public class EmailType : ObjectGraphType<EmailDto>
    {
        public EmailType()
        {
            Field(e => e.Id);
            Field(e => e.Label);
            Field(e => e.EmailAddress);
        }
    }
}
