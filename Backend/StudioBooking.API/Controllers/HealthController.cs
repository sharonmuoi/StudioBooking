using Microsoft.AspNetCore.Mvc;
namespace StudioBooking.API.Controllers;
[ApiController, Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet] public IActionResult Get() => Ok(new { status="ok", application="StudioBooking API", time=DateTime.UtcNow });
}
