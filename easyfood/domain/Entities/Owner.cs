namespace Easyfood.Domain.Entities
{
    public class Owner : BaseEntity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Guid UserId { get; private set; }

        public List<Partner> Partners { get; private set; }

        private Owner()
        {
        }

        public Owner(string firstName, string lastName, Guid userId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            Partners = new List<Partner>();
        }
    }
}