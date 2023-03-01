using Comments.Infrastructure.Auth.Models;
using FluentValidation;

namespace Comments.Infrastructure.Validators
{
    public class SignupModelValidator: AbstractValidator<SignupModel>
    {
        public SignupModelValidator()
        {
            RuleFor(s => s.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(s => s.HomePage)
                .Matches("(https?://)?([\\da-z.-]+)\\.([a-z.]{2,6})[/\\w .-]*/?");

            RuleFor(s => s.Password)
                .NotEmpty();

            RuleFor(s => s.UserName)
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}