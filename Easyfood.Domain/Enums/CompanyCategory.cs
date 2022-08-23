using System.ComponentModel;

namespace Easyfood.Partners.Domain.Enums
{
    public enum CompanyType
    {
        [Description("Restaurant")]
        Restaurant = 1,

        [Description("Pharmacy")]
        Pharmacy = 2,

        [Description("Market")]
        Market = 3
    }
}