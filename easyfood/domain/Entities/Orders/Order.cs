using Easyfood.Domain.Abstractions;
using Easyfood.Domain.Entities.Customers;
using Easyfood.Domain.Entities.Partners;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities.Orders
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; } = default!;

        public Guid PartnerId { get; private set; }

        public Partner Partner { get; private set; } = default!;

        public List<OrderItem> Items { get; private set; } = new();

        public Money TotalOrder { get; private set; }

        public int OrderNumber { get; private set; }

        public string OrderNumberDisplay => $"#{OrderNumber.ToString().PadLeft(10, '0')}";

        public bool IsValidOrder => Items.Count > 0;

        private Order()
        { }

        public Order(Guid customerId, Guid partnerId)
        {
            CustomerId = customerId;
            PartnerId = partnerId;
            TotalOrder = new Money(0);
        }

        public void AddItem(Guid orderId, Guid menuItemId, int quantity, Money unitPrice)
        {
            var orderItem = new OrderItem(orderId, menuItemId, quantity, unitPrice);
            Items.Add(orderItem);

            TotalOrder += orderItem.TotalPrice;
        }
    }
}