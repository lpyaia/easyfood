using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EasyfoodDbContext dbContext) : base(dbContext)
        {
        }
    }
}