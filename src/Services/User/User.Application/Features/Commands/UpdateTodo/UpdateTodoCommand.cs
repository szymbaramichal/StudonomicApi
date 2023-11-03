using MediatR;
using User.Application.Features.Commands.Shared;

namespace User.Application.Features.Commands.UpdateTodo;

public class UpdateTodoCommand : UpsertTodoCommandBase, IRequest
{
    public int Id { get; set; }
}