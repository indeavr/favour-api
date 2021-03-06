using FavourAPI.Dtos;
using GraphQL.Types;

namespace FavourAPI.GraphQL.Types
{
    public class OfficeType : ObjectGraphType<OfficeDto>
    {
        public OfficeType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field<LocationType>(nameof(OfficeDto.Location));
            Field<ListGraphType<IndustryType>>(nameof(OfficeDto.Industries));
            Field<ListGraphType<EmailType>>(nameof(OfficeDto.Emails));
            Field<ListGraphType<PhoneNumberType>>(nameof(OfficeDto.PhoneNumbers));
        }
    }
}
