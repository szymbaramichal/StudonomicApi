using MediatR;
using User.Application.Features.Commands.Shared;
using User.Application.Models.Todos;

namespace User.Application.Features.Commands.CreateTodo;

public class CreateTodoCommand : UpsertTodoCommandBase, IRequest<TodoViewModel> { }