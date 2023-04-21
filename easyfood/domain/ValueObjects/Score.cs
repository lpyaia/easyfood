using Easyfood.Domain.Exceptions;
using ValueOf;

namespace Easyfood.Domain.ValueObjects
{
    public class Score : ValueOf<decimal, Score>
    {
        protected override void Validate()
        {
            if (Value < 0 || Value > 5)
            {
                throw new DomainException("Score should be between 0 and 5.");
            }
        }
    }
}