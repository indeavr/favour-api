using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class PhoneNumberInputType : InputObjectGraphType<PhoneNumberDto>
    {
        public PhoneNumberInputType()
        {
            Field(pn => pn.Label);
            Field(pn => pn.Number);
        }
    }
}
