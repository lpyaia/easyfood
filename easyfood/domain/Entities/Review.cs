using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid PartnerId { get; private set; }

        public Partner? Partner { get; private set; }

        public string Opinion { get; private set; }

        public Score Rating { get; private set; }

        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; } = default!;

        private Review()
        {
        }

        public Review(Guid partnerId,
            string opinion,
            decimal rating,
            Guid customerId)
        {
            PartnerId = partnerId;
            Opinion = opinion;
            Rating = new Score(rating);
            CustomerId = customerId;
        }
    }
}