using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Commands.Labels.CreateLabel;
using User.Application.Features.Commands.Labels.UpdateLabel;
using User.Application.Models.Labels;

namespace User.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabelsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LabelsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));;
    }

    /// <summary>
    /// Create new label for todos
    /// </summary>
    /// <param name="command">Request body</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<LabelViewModel>> CreateLabel(CreateLabelCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    /// <summary>
    /// Update existing label
    /// </summary>
    /// <param name="command">Request body</param>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateLabel(UpdateLabelCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Delete existing label
    /// </summary>
    /// <param name="id">Label id</param>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteLabel(int id)
    {
        var command = new DeleteLabelCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
