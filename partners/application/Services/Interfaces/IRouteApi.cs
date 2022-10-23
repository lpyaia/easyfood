using Easyfood.Partners.Application.Models.Merchants;
using Easyfood.Partners.Domain.ValueObjects;

namespace Easyfood.Partners.Application.Services.Interfaces
{
    public interface IRouteApi
    {
        Task<DeliveryDto> GetDistance(Guid userId, Location from, Location to);
    }
}