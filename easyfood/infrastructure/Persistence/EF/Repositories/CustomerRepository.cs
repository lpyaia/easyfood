using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities.Customers;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EasyfoodDbContext dbContext) : base(dbContext)
        {
        }
    }
}