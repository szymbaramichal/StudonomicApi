using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.Commands.Labels.CreateLabel;

public class DeleteLabelCommandHandler : IRequestHandler<DeleteLabelCommand>
{
    private readonly ILabelsRepository _labelsRepository;

    public DeleteLabelCommandHandler(ILabelsRepository labelsRepository)
    {
        _labelsRepository = labelsRepository ?? throw new ArgumentNullException(nameof(labelsRepository));
    }

    public async Task<Unit> Handle(DeleteLabelCommand request, CancellationToken cancellationToken)
    {
        await _labelsRepository.DeleteLabel(request.Id);

        return Unit.Value;
    }
}