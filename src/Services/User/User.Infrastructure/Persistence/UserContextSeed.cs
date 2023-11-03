using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using User.Domain.Common;

namespace User.Infrastructure.Persistence
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(UserContext orderContext, ILogger<UserContextSeed> logger)
        {
            if (!orderContext.Todos.Any())
            {
                orderContext.Todos.AddRange(GetPreconfiguredTodos());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(UserContext).Name);
            }
        }

        private static IEnumerable<Todo> GetPreconfiguredTodos()
        {
            return new List<Todo>
            {
                new Todo() {
                    Title = "test"
                }
            };
        }
    }
}