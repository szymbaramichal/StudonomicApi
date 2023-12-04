using MediatR;
using User.Application.Features.Commands.Todos.Shared;
using User.Application.Models.Todos;

namespace User.Application.Features.Commands.Todos.CreateTodo;

public class CreateTodoCommand : UpsertTodoCommandBase, IRequest<TodoViewModel> { }