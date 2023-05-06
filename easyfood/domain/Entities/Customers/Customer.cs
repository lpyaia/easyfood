using Easyfood.Domain.Abstractions;
using Easyfood.Domain.Entities.Orders;
using Easyfood.Domain.Exceptions;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities.Customers
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public Name FirstName { get; set; }

        public Name LastName { get; set; }

        public Email Email { get; set; }

        public UserName UserName { get; set; }

        public DateTime BirthDate { get; set; }

        public IReadOnlyList<CreditCard> CreditCards => _creditCards;
        private readonly List<CreditCard> _creditCards = new();

        public IReadOnlyList<Review> Reviews => _reviews;
        private readonly List<Review> _reviews = new();

        public IReadOnlyList<Order> Orders => _orders;
        private readonly List<Order> _orders = new();

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

        public void RegisterCreditCard(CreditCard creditCard)
        {
            if (_creditCards.Count == 3)
                throw new DomainException("You should not be able to have more than 3 credit cards registered.");

            _creditCards.Add(creditCard);
        }

        public void UnregisterCreditCard(Guid creditCardId)
        {
            var creditCard = _creditCards.FirstOrDefault(x => x.Id == creditCardId);

            if (creditCard == null)
                throw new DomainException("Credit Card not found.");

            _creditCards.Remove(creditCard);
        }

        public bool HasCreditCard(Guid creditCardId)
        {
            return CreditCards.Any(x => x.Id == creditCardId);
        }
    }
}