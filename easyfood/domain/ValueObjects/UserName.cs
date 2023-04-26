using Easyfood.Domain.Exceptions;

namespace Easyfood.Domain.ValueObjects
{
    public class UserName : ValueObject
    {
        public static readonly int MAX_LENGTH = 50;
        public static readonly int MIN_LENGTH = 3;

        public string Value { get; init; }

        public UserName(string username)
        {
            Value = username;
            Validate();
        }

        private UserName()
        {
        }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new DomainException("Invalid username");
            }

            if (Value.Length > MAX_LENGTH ||
               Value.Length < MIN_LENGTH)
            {
                throw new DomainException($"Username should have length between {MIN_LENGTH} and {MAX_LENGTH}");
            }
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}