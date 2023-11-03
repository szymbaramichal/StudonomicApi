using User.Application.Contracts.Persistence;
using User.Domain.Common;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>, ITodoRepository
    {
        public TodoRepository(UserContext context) : base(context) { }

        public async Task<IEnumerable<Todo>> GetActiveTodosForDate(DateTime date)
        {
            return await GetAsync(x => x.DoDateUtc == date);
        }
    }
}