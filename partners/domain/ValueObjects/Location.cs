namespace Easyfood.Partners.Domain.ValueObjects
{
    public class Location : ValueObject
    {
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double GetDistance(Location to)
        {
            return 0d;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}