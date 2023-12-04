using FluentValidation;

namespace User.Application.Features.Commands.Todos.UpdateTodo;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{Title} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Title} must not exceed 50 characters.");

        RuleFor(p => p.DoDateUtc)
            .NotEmpty().WithMessage("{DoDateUtc} is required.");   
    }
}