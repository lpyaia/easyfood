using Easyfood.Domain.Exceptions;
using System.Text.RegularExpressions;
using ValueOf;

namespace Easyfood.Domain.ValueObjects
{
    public class Email : ValueOf<string, Email>
    {
        public static readonly int MAX_LENGTH = 250;
        public static readonly int MIN_LENGTH = 5;

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new DomainException("Email address cannot be null or empty.");
            }

            if (Value.Length > MAX_LENGTH || Value.Length < MIN_LENGTH)
            {
                throw new DomainException($"Email address should have length between {MIN_LENGTH} and {MAX_LENGTH}.");
            }

            if (!Regex.IsMatch(Value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new DomainException("Invalid email address format.");
            }
        }
    }
}