using FluentValidation;

namespace Comments.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator: AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(c => c.Text)
                .NotEmpty()
                .MaximumLength(10000);
        }
    }
}