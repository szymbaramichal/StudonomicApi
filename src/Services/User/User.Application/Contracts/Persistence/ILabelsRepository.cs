using User.Domain.Entities;

namespace User.Application.Contracts.Persistence;

public interface ILabelsRepository : IAsyncRepository<Label>
{
    Task DeleteLabel(int id);
}