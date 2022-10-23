using Easyfood.Partners.Application.Abstractions.Persistence;

namespace Easyfood.Partners.Infrastructure.Persistence.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PartnersDbContext _context;

        public UnitOfWork(PartnersDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}