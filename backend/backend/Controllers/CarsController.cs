using backend.Data.Scaffolded;
using backend.Models.Scaffolded;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly SupabaseDbContext _db;

    public CarsController(SupabaseDbContext db)
    {
        _db = db;
    }

    // GET api/cars/{id}
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var car = await _db.Cars
            .FirstOrDefaultAsync(c => c.id == id);

        if (car == null)
            return NotFound(new { message = $"Car {id} not found" });

        return Ok(car);
    }
}
