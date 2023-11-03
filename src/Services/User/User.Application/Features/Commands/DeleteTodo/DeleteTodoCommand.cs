using MediatR;

namespace User.Application.Features.Commands.DeleteTodo;

public class DeleteTodoCommand : IRequest
{
    public int Id { get; set; }  
}  