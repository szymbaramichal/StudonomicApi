using FluentValidation;

namespace User.Application.Features.Commands.Labels.CreateLabel
{
public class CreateLabelCommandValidator : AbstractValidator<CreateLabelCommand>
{
    public CreateLabelCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(15).WithMessage("{Name} must not exceed 15 characters.");
    }
}
}