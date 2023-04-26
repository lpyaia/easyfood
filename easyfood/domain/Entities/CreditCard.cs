using Easyfood.Domain.Exceptions;
using Easyfood.Domain.ValueObjects;
using System.Text.RegularExpressions;

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
            string expDate,
            string cardholderFirstName,
            string cardholderLastName)
        {
            Number = new CreditCardNumber(number);
            CVCCode = new CreditCardCVCCode(cvcCode);
            ExpDate = new CreditCardExpDate(expDate);
            CardholderFirstName = new Name(cardholderFirstName);
            CardholderLastName = new Name(cardholderLastName);
            Flag = GetCreditCardFlag(number);
        }

        public CreditCardFlag GetCreditCardFlag(string cardNumber)
        {
            var visaRgx = new Regex("^4");
            var masterRgx = new Regex("^5[1-5]");
            var amexRgx = new Regex("^3[47]");

            if (visaRgx.IsMatch(cardNumber))
                return CreditCardFlag.Visa;
            else if (masterRgx.IsMatch(cardNumber))
                return CreditCardFlag.MasterCard;
            else if (amexRgx.IsMatch(cardNumber))
                return CreditCardFlag.AmericanExpress;

            throw new DomainException("Invalid Credit Card Flag.");
        }
    }

    public enum CreditCardFlag
    {
        Visa = 1,
        MasterCard = 2,
        AmericanExpress = 3
    }
}