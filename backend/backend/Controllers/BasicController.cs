namespace backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using backend.Data;

[ApiController]
[Route("api/[controller]")]
public class BasicController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public BasicController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    [HttpGet("/test")]
    public IActionResult Get() => Ok(new { message = "Hello World!" });

    [HttpGet("db-check")]
    [HttpGet("/db-check")]
    public async Task<IActionResult> DbCheck()
    {
        try
        {
            var canConnect = await _db.Database.CanConnectAsync();
            return canConnect
                ? Ok(new { database = "ok" })
                : StatusCode(503, new { database = "unreachable" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { database = "error", error = ex.Message });
        }
    }
}


[ApiController]
[Route("api/[controller]")]
public class GrasuController : ControllerBase
{
    [HttpGet]
    [HttpGet("/grasu")]
    public IActionResult Get() => Ok(new { message = "Grasu e cel mai tare!" });
}
