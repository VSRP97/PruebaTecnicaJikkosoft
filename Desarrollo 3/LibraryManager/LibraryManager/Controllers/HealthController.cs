using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("Health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealthStatus()
        {
            return Ok();
        }
    }
}
