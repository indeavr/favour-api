using FavourAPI.Data.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.GraphQL.Types
{
    public class ConsumerType : ObjectGraphType<Consumer>
    {
        public ConsumerType()
        {
            Field(c => c.Id, type: typeof(IdGraphType)).Description("userId of the consumer");
            Field(c => c.FirstName);
            Field(c => c.LastName);
            //Field(c => c.User);
            Field(
                name: "Skills",
                type: typeof(SkillType)
            );
            Field(
                name: "DesiredPositions",
                type: typeof(ListGraphType<PositionType>),
                 resolve: context => context.Source.DesiredPositions
            );
            //Field(c => c.Experiences);
            //Field(c => c.Education);
            //Field(c => c.Location);
            //Field(c => c.PhoneNumber);
            //Field(c => c.ProfilePhoto);
            //Field(c => c.CV);
            //Field(c => c.CompletedJobs);
            //Field(c => c.SavedJobOffers);
        }
    }
}
