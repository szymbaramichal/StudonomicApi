using MediatR;
using User.Application.Features.Commands.Labels.Shared;
using User.Application.Models.Labels;

namespace User.Application.Features.Commands.Labels.CreateLabel;

public class CreateLabelCommand : UpsertLabelCommandBase, IRequest<LabelViewModel> 
{
    public int TaskId { get; set; }
}
