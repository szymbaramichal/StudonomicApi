using FluentValidation;

namespace User.Application.Features.Commands.Labels.UpdateLabel
{
public class UpdateLabelCommandValidator : AbstractValidator<UpdateLabelCommand>
{
    public UpdateLabelCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(15).WithMessage("{Name} must not exceed 15 characters.");
    }
}
}