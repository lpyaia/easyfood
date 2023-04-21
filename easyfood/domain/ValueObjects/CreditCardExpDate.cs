using Easyfood.Domain.Exceptions;
using ValueOf;

namespace Easyfood.Domain.ValueObjects
{
    public class CreditCardExpDate : ValueOf<DateTime, CreditCardExpDate>
    {
        protected override void Validate()
        {
            int currentMonth = DateTime.UtcNow.Month;
            int currentYear = DateTime.UtcNow.Year;
            bool isValid = Value.Month >= currentMonth && Value.Year >= currentYear;

            if (!isValid) throw new DomainException("Invalid Credit Card Expiration Date.");
        }
    }
}