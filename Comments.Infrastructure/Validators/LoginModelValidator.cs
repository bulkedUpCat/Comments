using Comments.Infrastructure.Auth.Models;
using FluentValidation;

namespace Comments.Infrastructure.Validators
{
    public class LoginModelValidator: AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(l => l.Password)
                .NotEmpty();
        }
    }
}