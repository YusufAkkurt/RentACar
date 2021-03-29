using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.UserId).NotEmpty();

            RuleFor(customer => customer.FindexPoint).GreaterThanOrEqualTo(0);
            RuleFor(customer => customer.FindexPoint).LessThanOrEqualTo(1900);
        }
    }
}