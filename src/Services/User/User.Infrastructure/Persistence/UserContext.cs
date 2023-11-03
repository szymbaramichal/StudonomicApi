using Microsoft.EntityFrameworkCore;
using User.Domain.Common;

namespace User.Infrastructure.Persistence;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDateUtc = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "TBD";
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedDateUtc = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = "TBD";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}