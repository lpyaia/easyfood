using Easyfood.Domain.Exceptions;

namespace Easyfood.Domain.ValueObjects
{
    public class CreditCardExpDate : ValueObject
    {
        public static readonly int LENGTH = 7;

        public DateTime Value { get; init; }

        public CreditCardExpDate(string expDate)
        {
            if (expDate.Length != LENGTH)
                throw new DomainException("Invalid Credit Card Expiration Date.");

            int month = int.Parse(expDate[0..2]);
            int year = int.Parse(expDate[3..]);

            Value = new DateTime(year, month, 1);

            Validate();
        }

        private CreditCardExpDate()
        {
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        protected override void Validate()
        {
            int currentMonth = DateTime.UtcNow.Month;
            int currentYear = DateTime.UtcNow.Year;
            bool isValid = Value.Year > currentYear || (Value.Year == currentYear && Value.Month >= currentMonth);

            if (!isValid) throw new DomainException("Invalid Credit Card Expiration Date.");
        }
    }
}