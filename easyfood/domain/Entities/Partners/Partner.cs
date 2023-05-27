using Easyfood.Domain.Abstractions;
using Easyfood.Domain.Entities.Customers;
using Easyfood.Domain.Entities.Orders;
using Easyfood.Domain.Entities.Owners;
using Easyfood.Domain.Enums;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities.Partners
{
    public class Partner : BaseEntity, IAggregateRoot
    {
        public string CompanyName { get; private set; }

        public string CompanyDescription { get; private set; }

        public string CompanyLogo { get; private set; }

        public CompanyType CompanyCategory { get; private set; }

        public bool IsActive { get; set; }

        public Score Score { get; set; }

        public Menu? Menu { get; private set; }

        public Address Address { get; private set; }

        public List<Review> Reviews { get; private set; }

        public Guid OwnerId { get; private set; }

        public Owner? Owner { get; private set; }

        public IReadOnlyList<Order> Orders => _orders;
        private readonly List<Order> _orders = new();

        public List<Tag> Tags { get; private set; } = new();

        private Partner()
        {
        }

        public Partner
        (
            string companyName,
            string companyDescription,
            string companyLogo,
            CompanyType companyCategory,
            Address address,
            Guid ownerId,
            decimal score
        )
        {
            CompanyName = companyName;
            CompanyDescription = companyDescription;
            CompanyLogo = companyLogo;
            CompanyCategory = companyCategory;
            Address = address;
            Reviews = new List<Review>();
            OwnerId = ownerId;
            Score = new Score(score);
            IsActive = true;
        }

        public void RegisterTag(Tag tag)
        {
            Tags.Add(tag);
        }
    }
}