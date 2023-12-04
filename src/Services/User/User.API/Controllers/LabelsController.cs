using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Commands.Labels.CreateLabel;
using User.Application.Features.Commands.Labels.UpdateLabel;

namespace User.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabelsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LabelsController(IMediator mediator)
    {
        _mediator = mediator  ?? throw new ArgumentNullException(nameof(mediator));;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateLabel([FromBody] CreateLabelCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateLabel([FromBody] UpdateLabelCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteTodo(int id)
    {
        var command = new DeleteLabelCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
