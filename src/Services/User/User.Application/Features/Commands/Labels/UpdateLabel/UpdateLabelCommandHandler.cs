using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Models.Labels;

namespace User.Application.Features.Commands.Labels.UpdateLabel;

public class UpdateLabelCommandHandler : IRequestHandler<UpdateLabelCommand, LabelViewModel>
{
    private readonly IMapper _mapper;
    private readonly ILabelsRepository _labelsRepository;

    public UpdateLabelCommandHandler(IMapper mapper, ILabelsRepository labelsRepository, ITodoRepository todoRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _labelsRepository = labelsRepository ?? throw new ArgumentNullException(nameof(labelsRepository));
    }

    public async Task<LabelViewModel> Handle(UpdateLabelCommand request, CancellationToken cancellationToken)
    {
        var labelEntity = await _labelsRepository.GetByIdAsync(request.LabelId);

        _mapper.Map(request, labelEntity);

        return _mapper.Map<LabelViewModel>(labelEntity);
    }
}