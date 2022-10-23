namespace Easyfood.Partners.Application.Models.Merchants
{
    public class DeliveryDto
    {
        public decimal DistanceInKilometers { get; set; }

        public int TimeToDeliverInMinutes { get; set; }

        public DeliveryDto(decimal distanceInKilometers, int timeToDeliverInMinutes)
        {
            DistanceInKilometers = distanceInKilometers;
            TimeToDeliverInMinutes = timeToDeliverInMinutes;
        }
    }
}