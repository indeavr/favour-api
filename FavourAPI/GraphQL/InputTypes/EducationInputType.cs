using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class EducationInputType : ObjectGraphType
    {
        public EducationInputType()
        {
            Name = "Education";
            Field<NonNullGraphType<StringGraphType>>("field");
        }
    }
}
