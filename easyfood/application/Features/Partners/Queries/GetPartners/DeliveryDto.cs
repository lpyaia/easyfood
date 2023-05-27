namespace Easyfood.Application.Features.Partners.Queries.GetPartners
{
    public class DeliveryDto
    {
        public decimal DistanceInKilometers { get; set; }

        public int TimeToDeliverInMinutes { get; set; }

        public decimal DeliveryPrice { get; set; }

        public DeliveryDto(decimal distanceInKilometers, int timeToDeliverInMinutes, decimal deliveryPrice)
        {
            DistanceInKilometers = distanceInKilometers;
            TimeToDeliverInMinutes = timeToDeliverInMinutes;
            DeliveryPrice = deliveryPrice;
        }
    }
}