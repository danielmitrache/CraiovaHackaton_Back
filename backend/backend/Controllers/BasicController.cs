namespace backend.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BasicController : ControllerBase
{
    [HttpGet]
    [HttpGet("/test")]
    public IActionResult Get() => Ok(new { message = "Hello World!" });

}


[ApiController]
[Route("api/[controller]")]
public class GrasuController : ControllerBase
{
    [HttpGet]
    [HttpGet("/grasu")]
    public IActionResult Get() => Ok(new { message = "Grasu e cel mai tare!" });
}
