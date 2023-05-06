using Easyfood.Domain.Entities.Partners;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities.Orders
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; private set; }

        public Order Order { get; private set; } = default!;

        public Guid ItemId { get; private set; }

        public MenuItem Item { get; private set; } = default!;

        public int Quantity { get; private set; }

        public Money TotalPrice { get; private set; }

        public Money UnitPrice { get; private set; }

        private OrderItem()
        { }

        public OrderItem(Guid orderId, Guid itemId, int quantity, Money unitPrice)
        {
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = Quantity * UnitPrice;
        }
    }
}