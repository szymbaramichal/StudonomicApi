using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using User.Application.Contracts.Persistence;
using User.Application.Models.Todos;
using User.Domain.Entities;

namespace User.Application.Features.Commands.Todos.CreateTodo;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoViewModel>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateTodoCommandHandler> _logger;

    public CreateTodoCommandHandler(IMapper mapper, ITodoRepository todoRepository, ILogger<CreateTodoCommandHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
    }

    public async Task<TodoViewModel> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        var todoEntity = _mapper.Map<Todo>(command);

        await _todoRepository.AddAsync(todoEntity);

        _logger.LogInformation($"Todo with id: {todoEntity.Id} has been added.");

        return _mapper.Map<TodoViewModel>(todoEntity);
    }
}