using Easyfood.Application.Abstractions.Persistence;

namespace Easyfood.Infrastructure.Persistence.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EasyfoodDbContext _context;

        public UnitOfWork(EasyfoodDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}