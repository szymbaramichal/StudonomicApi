using System.Runtime.InteropServices;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.Commands.UpdateTodo;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateTodoCommandHandler> _logger;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper, ILogger<UpdateTodoCommandHandler> logger)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoRepository.GetByIdAsync(request.Id);
        
        if(entity is null)
        {
            _logger.LogError($"Todo with id: {request.Id} doesn't not exist.");
        }

        _mapper.Map(request, entity);

        await _todoRepository.UpdateAsync(entity);

        return Unit.Value;
    }
}
