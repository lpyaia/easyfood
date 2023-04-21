using Easyfood.Domain.Exceptions;
using ValueOf;

namespace Easyfood.Domain.ValueObjects
{
    public class UserName : ValueOf<string, UserName>
    {
        public static readonly int MAX_LENGTH = 50;
        public static readonly int MIN_LENGTH = 3;

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
    }
}