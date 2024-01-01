using MediatR;
using Microsoft.Extensions.Logging;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.Commands.Todos.DeleteTodo;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{
    private readonly ITodoRepository _todoRepository;
    private readonly ILogger<DeleteTodoCommandHandler> _logger;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository, ILogger<DeleteTodoCommandHandler> logger)
    {
        _todoRepository = todoRepository;
        _logger = logger;
    }


    public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        await _todoRepository.DeleteTodo(request.Id);

        return Unit.Value;
    }
}