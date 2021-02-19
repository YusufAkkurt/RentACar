using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(color => color.Name).NotEmpty();
            RuleFor(color => color.Name).MinimumLength(2);
        }
    }
}