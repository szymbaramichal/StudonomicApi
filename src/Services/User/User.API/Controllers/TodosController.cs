using Microsoft.AspNetCore.Mvc;
using MediatR;
using User.Application.Models.Todos;
using System.Net;
using User.Application.Features.Commands.Todos.DeleteTodo;
using User.Application.Features.Commands.Todos.UpdateTodo;
using User.Application.Features.Commands.Todos.CreateTodo;
using User.Application.Features.Queries.GetTodosList;

namespace User.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodosController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Get todos for specific date
    /// </summary>
    /// <param name="dateTime">Date time</param>
    [HttpGet("{dateTime}")]
    [ProducesResponseType(typeof(IEnumerable<TodoViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<TodoViewModel>>> GetTodoByDateTime(DateTime dateTime)
    {
        var query = new GetTodosListQuery(dateTime);
        var orders = await _mediator.Send(query);
        return Ok(orders);
    }

    /// <summary>
    /// Create new todo
    /// </summary>
    /// <param name="command">Request body</param>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateTodo(CreateTodoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Update existing todo
    /// </summary>
    /// <param name="command">Request body</param>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateTodo(UpdateTodoCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Delete existing todo
    /// </summary>
    /// <param name="id">Todo id</param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteTodo(int id)
    {
        var command = new DeleteTodoCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}