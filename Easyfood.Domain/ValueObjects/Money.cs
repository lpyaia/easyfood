using Easyfood.Partners.Domain.Enums;
using Easyfood.Partners.Domain.Exception;

namespace Easyfood.Partners.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }

        public Currency Currency { get; private set; }

        public Money(decimal value)
        {
            if (value <= 0)
            {
                throw new DomainException("Price value should be greather than zero.");
            }

            Value = value;
            Currency = Currency.Reais;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}