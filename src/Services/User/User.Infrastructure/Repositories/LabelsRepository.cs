using Microsoft.EntityFrameworkCore;
using User.Application.Contracts.Persistence;
using User.Application.Exceptions;
using User.Domain.Entities;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class LabelsRepository : RepositoryBase<Label>, ILabelsRepository
    {
        public LabelsRepository(UserContext context) : base(context) { }

        public async Task DeleteLabel(int id)
        {
            var label = await _context.Labels.Where(x => x.Id == id).ExecuteDeleteAsync();

            if(label <= 0)
                throw new NotFoundException(nameof(label), label);
        }
    }
}