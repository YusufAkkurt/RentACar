using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(rental => rental.CarId).NotEmpty();
            RuleFor(rental => rental.CustomerId).NotEmpty();

            RuleFor(rental => rental.RentDate).NotEmpty();
        }
    }
}