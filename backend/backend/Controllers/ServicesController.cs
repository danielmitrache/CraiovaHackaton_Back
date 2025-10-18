using backend.DTOs;
using backend.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly ServiceHandler _handler;

    public ServicesController(ServiceHandler handler)
    {
        _handler = handler;
    }

    /// <summary>
    /// Get all services
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAll()
    {
        var services = await _handler.GetAllAsync();
        return Ok(services);
    }

    /// <summary>
    /// Get service by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceDto>> GetById(long id)
    {
        var service = await _handler.GetByIdAsync(id);
        if (service == null)
            return NotFound(new { message = $"Service with ID {id} not found" });

        return Ok(service);
    }

    /// <summary>
    /// Create a new service
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ServiceDto>> Create([FromBody] CreateServiceDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = await _handler.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
    }

    /// <summary>
    /// Update an existing service
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceDto>> Update(long id, [FromBody] UpdateServiceDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = await _handler.UpdateAsync(id, updateDto);
        if (service == null)
            return NotFound(new { message = $"Service with ID {id} not found" });

        return Ok(service);
    }

    /// <summary>
    /// Delete a service
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var success = await _handler.DeleteAsync(id);
        if (!success)
            return NotFound(new { message = $"Service with ID {id} not found" });

        return NoContent();
    }
}
