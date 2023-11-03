using MediatR;
using User.Application.Models.Todos;

namespace User.Application.Features.Queries.GetTodosList;

public class GetTodosListQuery : IRequest<List<TodoViewModel>>
{
    public DateTime Date { get; set; }

    public GetTodosListQuery(DateTime date)
    {
        Date = date;
    }
}