using backend.Data.Scaffolded;
using backend.DTOs;
using backend.Models.Scaffolded;
using Microsoft.EntityFrameworkCore;

namespace backend.Handlers;

public class ServiceHandler
{
    private readonly SupabaseDbContext _context;

    public ServiceHandler(SupabaseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync()
    {
        return await _context.Services
            .Include(s => s.city)
            .Select(s => new ServiceDto
            {
                Id = s.id,
                Name = s.name,
                NrEmployees = s.nr_employees,
                Description = s.description,
                Cui = s.cui,
                Address = s.address,
                CityId = s.city_id,
                CityName = s.city != null ? s.city.name : null,
                CanItp = s.can_itp
            })
            .ToListAsync();
    }

    public async Task<ServiceDto?> GetByIdAsync(long id)
    {
        var service = await _context.Services
            .Include(s => s.city)
            .FirstOrDefaultAsync(s => s.id == id);

        if (service == null)
            return null;

        return new ServiceDto
        {
            Id = service.id,
            Name = service.name,
            NrEmployees = service.nr_employees,
            Description = service.description,
            Cui = service.cui,
            Address = service.address,
            CityId = service.city_id,
            CityName = service.city != null ? service.city.name : null,
            CanItp = service.can_itp
        };
    }

    public async Task<ServiceDto> CreateAsync(CreateServiceDto createDto)
    {
        var service = new Service
        {
            name = createDto.Name,
            nr_employees = createDto.NrEmployees,
            description = createDto.Description,
            cui = createDto.Cui,
            address = createDto.Address,
            city_id = createDto.CityId,
            can_itp = createDto.CanItp ?? false
        };

        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        return new ServiceDto
        {
            Id = service.id,
            Name = service.name,
            NrEmployees = service.nr_employees,
            Description = service.description,
            Cui = service.cui,
            Address = service.address,
            CityId = service.city_id,
            CanItp = service.can_itp
        };
    }

    public async Task<ServiceDto?> UpdateAsync(long id, UpdateServiceDto updateDto)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
            return null;

        if (updateDto.Name != null)
            service.name = updateDto.Name;
        if (updateDto.NrEmployees.HasValue)
            service.nr_employees = updateDto.NrEmployees;
        if (updateDto.Description != null)
            service.description = updateDto.Description;
        if (updateDto.Cui != null)
            service.cui = updateDto.Cui;
        if (updateDto.Address != null)
            service.address = updateDto.Address;
        if (updateDto.CityId.HasValue)
            service.city_id = updateDto.CityId;
        if (updateDto.CanItp.HasValue)
            service.can_itp = updateDto.CanItp;

        await _context.SaveChangesAsync();

        return new ServiceDto
        {
            Id = service.id,
            Name = service.name,
            NrEmployees = service.nr_employees,
            Description = service.description,
            Cui = service.cui,
            Address = service.address,
            CityId = service.city_id,
            CanItp = service.can_itp
        };
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
            return false;

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
        return true;
    }
}
