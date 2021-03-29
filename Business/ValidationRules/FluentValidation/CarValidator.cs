using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.BrandId).NotEmpty();
            RuleFor(car => car.ColorId).NotEmpty();
            RuleFor(car => car.ModelYear).NotEmpty();

            RuleFor(car => car.DailyPrice).NotEmpty();
            RuleFor(car => car.DailyPrice).GreaterThan(0);

            RuleFor(car => car.Description).NotEmpty();
            RuleFor(car => car.Description).MinimumLength(2);

            RuleFor(car => car.FindexPoint).GreaterThanOrEqualTo(0);
            RuleFor(car => car.FindexPoint).LessThanOrEqualTo(1900);
        }
    }
}