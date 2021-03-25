using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user.FirstName).MinimumLength(2);
            RuleFor(user => user.LastName).MinimumLength(2);
            RuleFor(user => user.Password).MinimumLength(6);

            RuleFor(user => user.Email).EmailAddress();
        }
    }
}