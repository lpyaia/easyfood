using System.ComponentModel;

namespace Easyfood.Partners.Domain.Enums
{
    public enum Tag
    {
        [Description("Restaurant")]
        Restaurant = 1,

        [Description("Fast Food")]
        FastFood = 2,

        [Description("Italian")]
        Italian = 3,

        [Description("Chinese")]
        Chinese = 4,

        [Description("Mexican")]
        Mexican = 5,

        [Description("Pizza")]
        Pizza = 6,

        [Description("Burger")]
        Burger = 7,

        [Description("Candy Store")]
        CandyStore = 8,

        [Description("Healthy")]
        Healthy = 9,

        [Description("Beer")]
        Beer = 10,

        [Description("Drink")]
        Drink = 11
    }
}