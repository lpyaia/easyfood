using Easyfood.Domain.ValueObjects;

namespace Easyfood.Domain.Entities
{
    public class CreditCard : BaseEntity
    {
        public CreditCardNumber Number { get; private set; }

        public CreditCardCVCCode CVCCode { get; private set; }

        public CreditCardExpDate ExpDate { get; private set; }

        public Name CardholderFirstName { get; private set; }

        public Name CardholderLastName { get; private set; }

        public CreditCardFlag Flag { get; private set; }

        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; } = default!;

        private CreditCard()
        {
        }

        public CreditCard(string number,
            string cvcCode,
            DateTime expDate,
            string cardholderFirstName,
            string cardholderLastName,
            CreditCardFlag flag)
        {
            Number = CreditCardNumber.From(number);
            CVCCode = CreditCardCVCCode.From(cvcCode);
            ExpDate = CreditCardExpDate.From(expDate);
            CardholderFirstName = Name.From(cardholderFirstName);
            CardholderLastName = Name.From(cardholderLastName);
            Flag = flag;
        }
    }

    public enum CreditCardFlag
    {
        Visa = 1,
        MasterCard = 2,
        AmericanExpress = 3
    }
}