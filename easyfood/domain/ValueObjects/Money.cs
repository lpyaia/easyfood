using Easyfood.Domain.Enums;
using Easyfood.Domain.Exceptions;

namespace Easyfood.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }

        public Currency Currency { get; private set; }

        public Money(decimal value)
        {
            Value = value;
            Currency = Currency.Reais;
            Validate();
        }

        private Money()
        {
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }

        protected override void Validate()
        {
            if (Value < 0)
            {
                throw new DomainException("Money value shouldn't be less than zero.");
            }
        }

        public static implicit operator decimal(Money money) => money.Value;

        public static implicit operator Money(decimal value) => new Money(value);
    }
}