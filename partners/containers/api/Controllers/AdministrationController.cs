using Easyfood.Shared.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Easyfood.Partners.Api.Controllers
{
    [Route("api/admin")]
    [JwtAuthorization(Policy = "OnlyAdmin")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAdminGrant()
        {
            return Ok("Granted Admin access!");
        }

        [HttpGet("/super-admin")]
        [JwtAuthorization(Policy = "OnlySuperAdmin")]
        public ActionResult GetSuperAdminGrant()
        {
            return Ok("Granted Super Admin access!");
        }

        [HttpGet("/seasoned-worker")]
        [JwtAuthorization(Policy = "SeasonedWorker")]
        public ActionResult GetSeasonedWorker()
        {
            return Ok("Granted Seasoned Worker access!");
        }
    }
}