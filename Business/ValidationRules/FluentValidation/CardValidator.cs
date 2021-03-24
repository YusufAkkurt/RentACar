using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(card => card.CustomerId).NotEmpty();

            RuleFor(card => card.CardNumber).NotEmpty();
            RuleFor(card => card.CardNumber).Length(16);

            RuleFor(card => card.CardNameSurname).NotEmpty();

            RuleFor(card => card.CVV).NotEmpty();
            RuleFor(card => card.CVV).Length(3);

            RuleFor(card => card.ValidDate).NotEmpty();
        }
    }
}