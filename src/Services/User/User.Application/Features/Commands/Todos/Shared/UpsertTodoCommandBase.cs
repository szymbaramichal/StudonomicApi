namespace User.Application.Features.Commands.Todos.Shared;

public abstract class UpsertTodoCommandBase
{
    public string Title { get; set; } = string.Empty;
    public DateTime DoDateUtc { get; set; }
}
