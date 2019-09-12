﻿using FavourAPI.Data.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class CompanyProviderType: ObjectGraphType<CompanyProvider>
    {
        public CompanyProviderType()
        {
            Field(c => c.Id, type: typeof(IdGraphType)).Description("userId of the company");
            Field(c => c.Name);
        }
    }
}
