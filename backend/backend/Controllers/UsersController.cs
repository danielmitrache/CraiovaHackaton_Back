using backend.DTOs;
using backend.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserHandler _userHandler;

    public UsersController(UserHandler userHandler)
    {
        _userHandler = userHandler;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await _userHandler.GetAllAsync();
        return Ok(users);
    }

    // GET: api/users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(long id)
    {
        var user = await _userHandler.GetByIdAsync(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto createDto)
    {
        try
        {
            var user = await _userHandler.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> Update(long id, [FromBody] UpdateUserDto updateDto)
    {
        var user = await _userHandler.UpdateAsync(id, updateDto);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var result = await _userHandler.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
