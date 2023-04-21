using Easyfood.Domain.Exceptions;
using ValueOf;

namespace Easyfood.Domain.ValueObjects
{
    public class CreditCardNumber : ValueOf<string, CreditCardNumber>
    {
        protected override void Validate()
        {
            if (!long.TryParse(Value, out long cardNum))
            {
                throw new DomainException("Invalid Credit Card number.");
            }

            int sum = 0;
            bool alternate = false;

            for (int i = Value.Length - 1; i >= 0; i--)
            {
                int digit = (int)cardNum % 10;
                cardNum /= 10;

                if (alternate)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                alternate = !alternate;
            }

            bool isValid = sum % 10 == 0;

            if (!isValid) throw new DomainException("Invalid Credit Card number.");
        }
    }
}