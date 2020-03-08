using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.InputTypes
{
    public class OfficeInputType : InputObjectGraphType<OfficeDto>
    {
        public OfficeInputType()
        {
            Field(o => o.Name);
            //Field<ListGraphType<EmailInputType>>(nameof(OfficeDto.Emails));
            //Field<LocationInputType>(nameof(OfficeDto.Location));
            //Field<ListGraphType<PhoneNumberInputType>>(nameof(OfficeDto.PhoneNumbers));
        }
    }
}
