using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities.Orders;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(EasyfoodDbContext dbContext) : base(dbContext)
        {
        }
    }
}