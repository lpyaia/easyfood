using Easyfood.Domain.Exceptions;

namespace Easyfood.Domain.ValueObjects
{
    public class Score : ValueObject
    {
        public decimal Value { get; init; }

        public Score(decimal score)
        {
            Value = score;
            Validate();
        }

        private Score()
        {
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        protected override void Validate()
        {
            if (Value < 0 || Value > 5)
            {
                throw new DomainException("Score should be between 0 and 5.");
            }
        }
    }
}