namespace Easyfood.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string ZipCode { get; private set; }

        public string Country { get; private set; }

        public Location Location { get; private set; }

        private Address()
        { }

        public Address
        (
            string street,
            string city,
            string state,
            string zipCode,
            string country,
            double latitude,
            double longitude
        )
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Location = new Location(latitude, longitude);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return ZipCode;
            yield return Country;
        }
    }
}