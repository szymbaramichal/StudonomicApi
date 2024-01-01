using Microsoft.EntityFrameworkCore;
using User.Application.Contracts.Persistence;
using User.Application.Exceptions;
using User.Domain.Entities;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
    {
        public TodoRepository(UserContext context) : base(context) { }

        public async Task DeleteTodo(int id)
        {
            var todo = await _context.Todos.Where(x => x.Id == id).ExecuteDeleteAsync();

            if(todo <= 0)
                throw new NotFoundException(nameof(todo), todo);
        }

        public async Task<IEnumerable<Todo>> GetActiveTodosForDate(DateTime date)
        {
            return await GetAsync(x => x.DoDateUtc == date);
        }
    }
}