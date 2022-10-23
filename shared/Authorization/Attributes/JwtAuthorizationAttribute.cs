using Microsoft.AspNetCore.Authorization;

namespace Easyfood.Shared.Authorization.Attributes
{
    public class JwtAuthorizationAttribute : AuthorizeAttribute
    {
        public JwtAuthorizationAttribute()
        {
            AuthenticationSchemes = "Bearer";
        }

        public JwtAuthorizationAttribute(string policy) : base(policy)
        {
            AuthenticationSchemes = "Bearer";
        }
    }
}