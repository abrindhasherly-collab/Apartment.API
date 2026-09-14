using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories;

public class BuildingRepository : IBuildingRepository
{
    private readonly ApartmentDbContext _context;

    public BuildingRepository(ApartmentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Building>> GetAllAsync()
    {
        return await _context.Buildings
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Building?> GetByIdAsync(int id)
    {
        return await _context.Buildings
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Building> AddAsync(Building building)
    {
        await _context.Buildings.AddAsync(building);

        await _context.SaveChangesAsync();

        return building;
    }

    public async Task UpdateAsync(Building building)
    {
        _context.Buildings.Update(building);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var building =
            await _context.Buildings
                .FirstOrDefaultAsync(x => x.Id == id);

        if (building == null)
        {
            return;
        }

        _context.Buildings.Remove(building);

        await _context.SaveChangesAsync();
    }
}