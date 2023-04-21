using Easyfood.Domain.Abstractions;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public Name FirstName { get; set; }

        public Name LastName { get; set; }

        public Email Email { get; set; }

        public UserName UserName { get; set; }

        public DateTime BirthDate { get; set; }

        private readonly List<CreditCard> _creditCards = new();

        public IReadOnlyList<CreditCard> CreditCards => _creditCards;

        private readonly List<Review> _reviews = new();

        public IReadOnlyList<Review> Reviews => _reviews;

        private Customer()
        {
        }

        public Customer(Guid id,
            string firstName,
            string lastName,
            string email,
            string userName,
            DateTime birthDate)
        {
            Id = id;
            FirstName = Name.From(firstName);
            LastName = Name.From(lastName);
            Email = Email.From(email);
            UserName = UserName.From(userName);
            BirthDate = birthDate;
        }
    }
}