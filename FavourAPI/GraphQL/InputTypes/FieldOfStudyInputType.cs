using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class FieldOfStudyInputType : InputObjectGraphType<FieldOfStudyDto>
    {
        public FieldOfStudyInputType()
        {
            Field(fos => fos.Id);
            Field(fos => fos.Name);
        }
    }
}
