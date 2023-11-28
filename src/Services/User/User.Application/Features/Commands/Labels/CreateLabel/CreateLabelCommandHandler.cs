using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Models.Labels;
using User.Domain.Entities;

namespace User.Application.Features.Commands.Labels.CreateLabel;

public class CreateLabelCommandHandler : IRequestHandler<CreateLabelCommand, LabelViewModel>
{
    private readonly IMapper _mapper;
    private readonly ILabelsRepository _labelsRepository;
    private readonly ITodoRepository _todoRepository;

    public CreateLabelCommandHandler(IMapper mapper, ILabelsRepository labelsRepository, ITodoRepository todoRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _labelsRepository = labelsRepository ?? throw new ArgumentNullException(nameof(labelsRepository));
        _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
    }

    public async Task<LabelViewModel> Handle(CreateLabelCommand request, CancellationToken cancellationToken)
    {
        var labelEntity = _mapper.Map<Label>(request);

        await _labelsRepository.AddAsync(labelEntity);

        if(request.TaskId != 0)
        {
            var todo = await _todoRepository.GetByIdAsync(request.TaskId);

            todo.Label = labelEntity;

            await _todoRepository.UpdateAsync(todo);
        }

        return _mapper.Map<LabelViewModel>(labelEntity);
    }
}