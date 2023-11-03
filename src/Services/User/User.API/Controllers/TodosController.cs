using Microsoft.AspNetCore.Mvc;
using MediatR;
using User.Application.Models.Todos;
using System.Net;
using User.Application.Features.Commands.DeleteTodo;
using User.Application.Features.Commands.UpdateTodo;
using User.Application.Features.Commands.CreateTodo;
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

        [HttpGet("{dateTime}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<TodoViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoViewModel>>> GetOrdersByUserName(DateTime dateTime)
        {
            var query = new GetTodosListQuery(dateTime);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        // testing purpose
        [HttpPost(Name = "Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTodo([FromBody] CreateTodoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTodo([FromBody] UpdateTodoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "Delete")]
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