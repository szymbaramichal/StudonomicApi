using MediatR;
using User.Application.Features.Commands.Todos.Shared;

namespace User.Application.Features.Commands.Todos.UpdateTodo;

public class UpdateTodoCommand : UpsertTodoCommandBase, IRequest
{
    public int Id { get; set; }
    public int LabelId { get; set; }
    public bool IsDone { get; set; }
}