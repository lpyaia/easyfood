using Easyfood.Domain.Exceptions;
using ValueOf;

namespace Easyfood.Domain.ValueObjects
{
    public class Name : ValueOf<string, Name>
    {
        public static readonly int MAX_LENGTH = 100;
        public static readonly int MIN_LENGTH = 3;

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
    }
}