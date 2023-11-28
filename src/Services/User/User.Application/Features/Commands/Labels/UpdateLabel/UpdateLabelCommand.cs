using MediatR;
using User.Application.Features.Commands.Labels.Shared;
using User.Application.Models.Labels;

namespace User.Application.Features.Commands.Labels.UpdateLabel;

public class UpdateLabelCommand : UpsertLabelCommandBase, IRequest<LabelViewModel> 
{
    public int LabelId { get; set; }
}
