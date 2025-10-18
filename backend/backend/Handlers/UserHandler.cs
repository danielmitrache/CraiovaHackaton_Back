using backend.Data.Scaffolded;
using backend.DTOs;
using backend.Models.Scaffolded;
using Microsoft.EntityFrameworkCore;

namespace backend.Handlers;

public class UserHandler
{
    private readonly SupabaseDbContext _context;

    public UserHandler(SupabaseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.idNavigation)
            .Select(u => new UserDto
            {
                Id = u.id,
                Name = u.name,
                Email = u.idNavigation != null ? u.idNavigation.email : null
            })
            .ToListAsync();
    }

    public async Task<UserDto?> GetByIdAsync(long id)
    {
        var user = await _context.Users
            .Include(u => u.idNavigation)
            .FirstOrDefaultAsync(u => u.id == id);

        if (user == null)
            return null;

        return new UserDto
        {
            Id = user.id,
            Name = user.name,
            Email = user.idNavigation != null ? user.idNavigation.email : null
        };
    }

    public async Task<UserDto> CreateAsync(CreateUserDto createDto)
    {
        // First create the login
        var login = new Login
        {
            email = createDto.Email,
            password = createDto.Password // Note: In production, you should hash this!
        };

        _context.Logins.Add(login);
        await _context.SaveChangesAsync();

        // Then create the user with the same ID as login
        var user = new User
        {
            id = login.id,
            name = createDto.Name
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.id,
            Name = user.name,
            Email = login.email
        };
    }

    public async Task<UserDto?> UpdateAsync(long id, UpdateUserDto updateDto)
    {
        var user = await _context.Users
            .Include(u => u.idNavigation)
            .FirstOrDefaultAsync(u => u.id == id);

        if (user == null)
            return null;

        // Update user fields
        if (updateDto.Name != null)
            user.name = updateDto.Name;

        // Update login fields
        if (user.idNavigation != null)
        {
            if (updateDto.Email != null)
                user.idNavigation.email = updateDto.Email;
            if (updateDto.Password != null)
                user.idNavigation.password = updateDto.Password; // Note: In production, you should hash this!
        }

        await _context.SaveChangesAsync();

        return new UserDto
        {
            Id = user.id,
            Name = user.name,
            Email = user.idNavigation != null ? user.idNavigation.email : null
        };
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _context.Users
            .Include(u => u.idNavigation)
            .FirstOrDefaultAsync(u => u.id == id);

        if (user == null)
            return false;

        // Remove user first
        _context.Users.Remove(user);
        
        // Then remove login
        if (user.idNavigation != null)
        {
            _context.Logins.Remove(user.idNavigation);
        }

        await _context.SaveChangesAsync();
        return true;
    }
}
