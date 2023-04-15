using Easyfood.Domain.Abstractions;

namespace Easyfood.Domain.Entities
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public DateTime BirthDate { get; set; }

        private Customer(Guid id,
            string firstName,
            string lastName,
            string email,
            string userName,
            DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            BirthDate = birthDate;
        }

        public static Customer CreateCustomer(Guid id,
            string firstName,
            string lastName,
            string email,
            string userName,
            DateTime birthDate)
        {
            return new Customer(id, firstName, lastName, email, userName, birthDate);
        }
    }
}