using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.Commands.Todos.UpdateTodo;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
{
    private readonly ITodoRepository _todoRepository;
    private readonly ILabelsRepository _labelsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateTodoCommandHandler> _logger;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper, ILogger<UpdateTodoCommandHandler> logger, ILabelsRepository labelsRepository)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
        _logger = logger;
        _labelsRepository = labelsRepository;
    }

    public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _todoRepository.GetByIdAsync(request.Id);
        
        if(entity is null)
        {
            _logger.LogError($"Todo with id: {request.Id} doesn't not exist.");
        }

        _mapper.Map(request, entity);

        if(request.LabelId != 0)
        {
            var label = await _labelsRepository.GetByIdAsync(request.LabelId);

            entity.Label = label;
        }

        await _todoRepository.UpdateAsync(entity);

        return Unit.Value;
    }
}
