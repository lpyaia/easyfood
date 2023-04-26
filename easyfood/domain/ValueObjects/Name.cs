using Easyfood.Domain.Exceptions;

namespace Easyfood.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public static readonly int MAX_LENGTH = 100;
        public static readonly int MIN_LENGTH = 3;

        public string Value { get; init; }

        public Name(string name)
        {
            Value = name;
            Validate();
        }

        private Name()
        {
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Value) || !Value.All(char.IsLetter))
            {
                throw new DomainException("Invalid Name.");
            }

            if (Value.Length > MAX_LENGTH || Value.Length < MIN_LENGTH)
            {
                throw new DomainException($"Name should have length between {MIN_LENGTH} and {MAX_LENGTH}.");
            }
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}