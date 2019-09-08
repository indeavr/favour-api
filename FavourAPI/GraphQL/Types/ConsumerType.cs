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
            Field(c => c.Id);
            Field(c => c.FirstName);
            Field(c => c.LastName);
            Field(c => c.User);
            //Field(c => c.Skills);
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
