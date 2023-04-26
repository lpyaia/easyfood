using Easyfood.Domain.Exceptions;

namespace Easyfood.Domain.ValueObjects
{
    public class CreditCardCVCCode : ValueObject
    {
        public static readonly int LENGTH = 3;

        public string Value { get; init; }

        public CreditCardCVCCode(string value)
        {
            Value = value;
            Validate();
        }

        private CreditCardCVCCode()
        {
        }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value) ||
                Value.Length != LENGTH ||
                !int.TryParse(Value, out int _))
            {
                throw new DomainException("Invalid Credit Card CVC Code.");
            }
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}