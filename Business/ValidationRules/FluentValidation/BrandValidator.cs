using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.Name).NotEmpty();
            RuleFor(brand => brand.Name).MinimumLength(2);
        }
    }
}