using MediatR;

namespace User.Application.Features.Commands.Labels.CreateLabel;

public class DeleteLabelCommand : IRequest
{
    public int Id { get; set; }
}
