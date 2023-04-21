using Easyfood.Domain.Exceptions;
using ValueOf;

namespace Easyfood.Domain.ValueObjects
{
    public class CreditCardCVCCode : ValueOf<string, CreditCardCVCCode>
    {
        public static readonly int LENGTH = 3;

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value) ||
                Value.Length != LENGTH ||
                !int.TryParse(Value, out int _))
            {
                throw new DomainException("Invalid Credit Card CVC Code.");
            }
        }
    }
}