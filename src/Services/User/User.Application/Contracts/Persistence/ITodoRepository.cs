using User.Domain.Entities;

namespace User.Application.Contracts.Persistence;

public interface ITodoRepository : IAsyncRepository<Todo>
{
   Task<IEnumerable<Todo>> GetActiveTodosForDate(DateTime date);
   Task DeleteTodo(int id);
}