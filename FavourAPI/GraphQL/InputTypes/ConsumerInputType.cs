using FavourAPI.Data.Models;
using FavourAPI.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ConsumerInputType : InputObjectGraphType<ConsumerType>
    {
        public ConsumerInputType()
        {
            Name = "Consumer";

            Field<StringGraphType>("firstName");

            Field<StringGraphType>("lastName");

            //Field<StringGraphType>("phoneNumber");

            Field<LocationInputType>("location");

            //Field<StringGraphType>("sex");

            Field<ListGraphType<StringGraphType>>("skills");

            Field<ListGraphType<StringGraphType>>("desiredPositions");

            Field<StringGraphType>("profilePhoto");

            Field<ListGraphType<ExperienceInputType>>("experiences");

            Field<ListGraphType<EducationInputType>>("educations");
        }
    }

    public class LocationInputType : InputObjectGraphType<Location>
    {
        public LocationInputType()
        {
            Name = "Location";

            Field<NonNullGraphType<StringGraphType>>("town");
        }
    }

    public class ExperienceInputType : InputObjectGraphType<Experience>
    {
        public ExperienceInputType()
        {
            Name = "Experience";

            Field<NonNullGraphType<StringGraphType>>("position");
        }
    }

    public class EducationInputType : InputObjectGraphType<Education>
    {
        public EducationInputType()
        {
            Name = "Education";

            Field<NonNullGraphType<StringGraphType>>("field");
        }
    }
}
