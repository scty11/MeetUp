using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Api.Controllers
{

    [Produces("application/json")]
    [Route("api/HealthCheck")]
    public class HealthCheckController : Controller
    {

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}