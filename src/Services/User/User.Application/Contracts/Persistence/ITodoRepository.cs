using User.Domain.Common;

namespace User.Application.Contracts.Persistence;

public interface ITodoRepository : IAsyncRepository<Todo>
{
   Task<IEnumerable<Todo>> GetActiveTodosForDate(DateTime date);
}