using Microsoft.AspNetCore.Authorization;

namespace Easyfood.Shared.Authorization.Requirements
{
    public class SeasonedWorkerRequirement : IAuthorizationRequirement
    {
        public int MinimumWorkingTime => 10;
    }
}