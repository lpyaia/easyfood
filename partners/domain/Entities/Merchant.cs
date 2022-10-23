using Easyfood.Partners.Domain.Abstractions;
using Easyfood.Partners.Domain.Enums;
using Easyfood.Partners.Domain.ValueObjects;

namespace Easyfood.Partners.Domain.Entities
{
    public class Merchant : BaseEntity, IAggregateRoot
    {
        public string CompanyName { get; private set; }

        public string CompanyDescription { get; private set; }

        public string CompanyLogo { get; private set; }

        public CompanyType CompanyCategory { get; private set; }

        public List<Tag> Tags { get; private set; }

        public Guid MenuId { get; private set; }

        public Menu? Menu { get; private set; }

        public Address Address { get; private set; }

        public List<Review> Reviews { get; private set; }

        public Guid OwnerId { get; private set; }

        public Owner? Owner { get; private set; }

        private Merchant()
        {
        }

        public Merchant
        (
            string companyName,
            string companyDescription,
            string companyLogo,
            CompanyType companyCategory,
            Guid menuId,
            Address address,
            Guid ownerId
        )
        {
            CompanyName = companyName;
            CompanyDescription = companyDescription;
            CompanyLogo = companyLogo;
            CompanyCategory = companyCategory;
            MenuId = menuId;
            Address = address;
            Tags = new List<Tag>();
            Reviews = new List<Review>();
            OwnerId = ownerId;
        }

        public void RegisterTag(Tag tag)
        {
            Tags.Add(tag);
        }
    }
}