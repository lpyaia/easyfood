using Easyfood.Domain.Exceptions;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities.Orders
{
    public class OrderBuilder
    {
        private readonly Order _order;

        private OrderBuilder(Order order)
        {
            _order = order;
        }

        public static OrderBuilder CreateOrder(Guid customerId, Guid partnerId)
        {
            return new OrderBuilder(new Order(customerId, partnerId));
        }

        public OrderBuilder AddItem(Guid menuItemId, int quantity, Money unitPrice)
        {
            _order.AddItem(_order.Id,
                menuItemId,
                quantity,
                unitPrice);

            return this;
        }

        public Order Create()
        {
            if (!_order.IsValidOrder)
            {
                throw new DomainException("Order don't have items.");
            }

            return _order;
        }
    }
}