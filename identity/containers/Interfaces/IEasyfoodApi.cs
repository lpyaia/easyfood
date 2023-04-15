using Refit;

namespace Easyfood.Identity.Interfaces
{
    public interface IEasyfoodApi
    {
        [Post("/api/customers")]
        Task CreateUser([Body] CreateNewCustomerDto body, [Header("subscription-key")] string subscriptionKey);
    }

    public record CreateNewCustomerDto(Guid UserId,
        string UserName,
        string Email,
        string FirstName,
        string LastName,
        DateTime BirthDate);
}