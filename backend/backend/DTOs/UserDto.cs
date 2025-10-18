namespace backend.DTOs;

public class UserDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
}

public class CreateUserDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class UpdateUserDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
