using MediatR;

namespace User.Application.Features.Commands.Todos.DeleteTodo;

public class DeleteTodoCommand : IRequest
{
    public int Id { get; set; }  
}  