﻿using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.GraphQLTypes
{
    public class PhoneNumberType : ObjectGraphType<PhoneNumberDto>
    {
        public PhoneNumberType()
        {
            Field(pn => pn.Id);
            Field(pn => pn.Label);
            Field(pn => pn.Number);
        }
    }
}
