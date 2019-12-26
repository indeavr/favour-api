using FavourAPI.Dtos;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class EducationType : ObjectGraphType<EducationDto>
    {
        //public string Id { get; set; }

        //public FieldOfStudyDto Field { get; set; }

        //public DateTime Start { get; set; }

        //public DateTime End { get; set; }

        public EducationType()
        {
            Field(e => e.Id);
        }
    }
}
