using Easyfood.Domain.Abstractions;
using Easyfood.Domain.Enums;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities
{
    public class Partner : BaseEntity, IAggregateRoot
    {
        public string CompanyName { get; private set; }

        public string CompanyDescription { get; private set; }

        public string CompanyLogo { get; private set; }

        public CompanyType CompanyCategory { get; private set; }

        public bool IsActive { get; set; }

        public decimal Score { get; set; }

        public List<Tag> Tags { get; private set; }

        public Guid MenuId { get; private set; }

        public Menu? Menu { get; private set; }

        public Address Address { get; private set; }

        public List<Review> Reviews { get; private set; }

        public Guid OwnerId { get; private set; }

        public Owner? Owner { get; private set; }

        private Partner()
        {
        }

        public Partner
        (
            string companyName,
            string companyDescription,
            string companyLogo,
            CompanyType companyCategory,
            Guid menuId,
            Address address,
            Guid ownerId,
            decimal score
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
            Score = score;
            IsActive = true;
        }

        public void RegisterTag(Tag tag)
        {
            Tags.Add(tag);
        }
    }
}