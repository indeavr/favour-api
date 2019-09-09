using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ConsumerInputType : InputObjectGraphType
    {
        public ConsumerInputType()
        {
            Name = "ConsumerInput";

            Field<NonNullGraphType<StringGraphType>>("firstName");

            Field<NonNullGraphType<StringGraphType>>("lastName");

            Field<NonNullGraphType<StringGraphType>>("phoneNumber");

            Field<NonNullGraphType<LocationInputType>>("location");

            Field<NonNullGraphType<StringGraphType>>("sex");

            Field<ListGraphType<StringGraphType>>("skills");

            Field<ListGraphType<StringGraphType>>("desiredPositions");

            Field<StringGraphType>("profilePhoto");

            Field<ListGraphType<ExperienceInputType>>("experiences");

            Field<ListGraphType<EducationInputType>>("educations");
        }
    }

    public class LocationInputType : InputObjectGraphType
    {
        public LocationInputType()
        {
            Name = "LocationInput";

            Field<NonNullGraphType<StringGraphType>>("town");
        }
    }

    public class ExperienceInputType : InputObjectGraphType
    {
        public ExperienceInputType()
        {
            Name = "ExperienceInput";

            Field<NonNullGraphType<StringGraphType>>("position");
        }
    }

    public class EducationInputType : InputObjectGraphType
    {
        public EducationInputType()
        {
            Name = "EducationInput";

            Field<NonNullGraphType<StringGraphType>>("field");
        }
    }
}
