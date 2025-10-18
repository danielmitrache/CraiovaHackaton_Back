using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public CarsController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET /api/cars/{id}
    [HttpGet("{id:long}")]
    public async Task<ActionResult<car>> GetById(long id, CancellationToken ct)
    {
        var entity = await _db.cars.FindAsync(new object[] { id }, ct);
        if (entity is null)
            return NotFound();
        return Ok(entity);
    }
}

