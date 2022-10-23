using Easyfood.Partners.Domain.ValueObjects;

namespace Easyfood.Shared.Common.User
{
    public class UserService
    {
        public static Guid Id = Guid.NewGuid();

        public Location Location => new Location(-23.5452315, -47.5021542);
    }
}