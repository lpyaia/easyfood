using Easyfood.Shared.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace Easyfood.Shared.Authorization.Handlers
{
    public class SeasonedWorkerRequirementHandler : AuthorizationHandler<SeasonedWorkerRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SeasonedWorkerRequirement requirement)
        {
            var user = context.User;
            var birthDateClaim = user.FindFirst("employeeSince");

            if (birthDateClaim != null)
            {
                DateTime birthDate = DateTime.Parse(birthDateClaim.Value);
                TimeSpan diff = DateTime.Today.Subtract(birthDate);

                double yearsWorking = diff.TotalDays / 365.25;

                if (yearsWorking >= requirement.MinimumWorkingTime)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}