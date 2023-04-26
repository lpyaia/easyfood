using Easyfood.Domain.Abstractions;
using Easyfood.Domain.Exceptions;
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
            FirstName = new Name(firstName);
            LastName = new Name(lastName);
            Email = new Email(email);
            UserName = new UserName(userName);
            BirthDate = birthDate;
        }

        public void AddCreditCard(CreditCard creditCard)
        {
            if (CreditCards.Count > 3)
                throw new DomainException("You should not be able to have more than 3 credit cards registered.");

            _creditCards.Add(creditCard);
        }
    }
}