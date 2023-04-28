using Easyfood.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Easyfood.Domain.ValueObjects
{
    public class CreditCardNumber : ValueObject
    {
        public string Value { get; init; }

        public CreditCardNumber(string number)
        {
            Value = number;
            Validate();
        }

        private CreditCardNumber()
        {
        }

        protected override void Validate()
        {
            string value = Value.Trim().Replace("-", "");

            if (!long.TryParse(value, out long cardNum))
            {
                throw new DomainException("Invalid Credit Card number.");
            }

            int[] digits = value.Replace(" ", "") // Remove any spaces in the number
                                .Select(c => int.Parse(c.ToString())) // Convert each character to an integer
                                .Reverse() // Reverse the digits to simplify the Luhn algorithm
                                .ToArray();

            int checksum = digits.Select((d, i) => i % 2 == 0 ? d : (d * 2) % 10 + (d * 2) / 10) // Double every other digit starting from the second-to-last
                                 .Sum(); // Add up all the digits

            var visaRgx = new Regex("^4");
            var masterRgx = new Regex("^5[1-5]");
            var amexRgx = new Regex("^3[47]");

            bool isValid = checksum % 10 == 0 &&
                           (
                               visaRgx.Match(value).Success ||
                               masterRgx.Match(value).Success ||
                               amexRgx.Match(value).Success
                           );

            if (!isValid) throw new DomainException("Invalid Credit Card number.");
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}