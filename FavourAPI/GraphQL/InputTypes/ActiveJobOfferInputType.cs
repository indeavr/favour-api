using FavourAPI.Dtos;
using GraphQL.Types;
using System.Security.Claims;

namespace FavourAPI.GraphQL.InputTypes
{
    public class ActiveJobOfferInputType : InputObjectGraphType<ActiveJobOfferDto>
    {
        public ActiveJobOfferInputType()
        {
            Field(ajo => ajo.Id);
            Field(ajo => ajo.IsDeleted);

            Field<ListGraphType<ApplicationInputType>>(nameof(ActiveJobOfferDto.Applications));
            Field<JobOfferInputType>(nameof(ActiveJobOfferDto.JobOffer));
        }
    }

    public class Gosho: ClaimsPrincipal
    {
      
    }
}
