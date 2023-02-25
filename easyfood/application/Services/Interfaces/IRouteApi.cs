using Easyfood.Application.Models.Partners;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Application.Services.Interfaces
{
    public interface IRouteApi
    {
        Task<DeliveryDto> GetDistance(Guid userId, Guid partnerId, Location from, Location to);
    }
}