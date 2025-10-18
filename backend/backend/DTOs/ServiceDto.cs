namespace backend.DTOs;

public class ServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public int? NrEmployees { get; set; }
    public string? Description { get; set; }
    public string? Cui { get; set; }
    public string? Address { get; set; }
    public long? CityId { get; set; }
    public string? CityName { get; set; }
    public bool? CanItp { get; set; }
}

public class CreateServiceDto
{
    public string Name { get; set; } = null!;
    public int? NrEmployees { get; set; }
    public string? Description { get; set; }
    public string? Cui { get; set; }
    public string? Address { get; set; }
    public long? CityId { get; set; }
    public bool? CanItp { get; set; }
}

public class UpdateServiceDto
{
    public string? Name { get; set; }
    public int? NrEmployees { get; set; }
    public string? Description { get; set; }
    public string? Cui { get; set; }
    public string? Address { get; set; }
    public long? CityId { get; set; }
    public bool? CanItp { get; set; }
}
