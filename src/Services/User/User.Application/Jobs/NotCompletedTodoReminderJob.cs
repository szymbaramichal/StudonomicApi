using Microsoft.Extensions.Logging;
using User.Application.Contracts.Persistence;

namespace User.Application.Jobs;

public class NotCompletedTodoReminderJob
{
    protected ITodoRepository _todoRepository;
    private ILogger<NotCompletedTodoReminderJob> _logger;
    public NotCompletedTodoReminderJob(ITodoRepository todoRepository, ILogger<NotCompletedTodoReminderJob> logger)
    {
        _todoRepository = todoRepository;
        _logger = logger;
    }

    public void Execute() 
    {
        //TODO: COMPLETE WHEN PROFILE WILL BE ADDED
        //TODO: Register job in Registration file.
    }
}