using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerUpdateValidator : AbstractValidator<CustomerDetailDto>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(customerDetail => customerDetail.Id).NotEmpty();
            RuleFor(customerDetail => customerDetail.UserId).NotEmpty();
            RuleFor(customerDetail => customerDetail.FirstName).NotEmpty();
            RuleFor(customerDetail => customerDetail.LastName).NotEmpty();
            RuleFor(customerDetail => customerDetail.Email).NotEmpty();
        }
    }
}