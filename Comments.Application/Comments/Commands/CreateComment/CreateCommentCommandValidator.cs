using FluentValidation;

namespace Comments.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator: AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Text)
                .NotEmpty()
                .MaximumLength(10000);
        }
    }
}