using Easyfood.Partners.Domain.Exceptions;

namespace Easyfood.Partners.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid MerchantId { get; private set; }

        public Merchant? Merchant { get; private set; }

        public string Opinion { get; private set; }

        public decimal Rating { get; private set; }

        public string UserName { get; private set; }

        private Review()
        { }

        public Review(Guid merchantId, string opinion, decimal rating, string userName)
        {
            if (rating > 5 || rating < 0)
                throw new DomainException($"Rating value is invalid: {rating}.");

            MerchantId = merchantId;
            Opinion = opinion;
            Rating = rating;
            CreatedAt = DateTime.UtcNow;
            UserName = userName;
        }
    }
}