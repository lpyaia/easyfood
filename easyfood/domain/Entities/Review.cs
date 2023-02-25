using Easyfood.Domain.Exceptions;

namespace Easyfood.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid PartnerId { get; private set; }

        public Partner? Partner { get; private set; }

        public string Opinion { get; private set; }

        public decimal Rating { get; private set; }

        public string UserName { get; private set; }

        private Review()
        { }

        public Review(Guid partnerId, string opinion, decimal rating, string userName)
        {
            if (rating > 5 || rating < 0)
                throw new DomainException($"Rating value is invalid: {rating}.");

            PartnerId = partnerId;
            Opinion = opinion;
            Rating = rating;
            CreatedAt = DateTime.UtcNow;
            UserName = userName;
        }
    }
}