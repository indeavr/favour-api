using GraphQL.Validation;

namespace FavourAPI
{
    public class InputValidationRule : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            return new EnterLeaveListener(_ =>
            {
            });
        }
    }
}