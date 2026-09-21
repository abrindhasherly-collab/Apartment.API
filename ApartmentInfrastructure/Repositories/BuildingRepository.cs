using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories;

public class BuildingRepository : IBuildingRepository
{
    private readonly ApartmentDbcontext _context;

    public BuildingRepository(ApartmentDbcontext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Building>> GetAllAsync()
    {
        return await _context.Qwin9Buildings
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Building?> GetByIdAsync(int id)
    {
        return await _context.Qwin9Buildings
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Building> AddAsync(Building building)
    {
        await _context.Qwin9Buildings.AddAsync(building);

        await _context.SaveChangesAsync();

        return building;
    }

    public async Task UpdateAsync(Building building)
    {
        _context.Qwin9Buildings.Update(building);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var building =
            await _context.Qwin9Buildings
                .FirstOrDefaultAsync(x => x.Id == id);

        if (building == null)
        {
            return;
        }

        _context.Qwin9Buildings.Remove(building);

        await _context.SaveChangesAsync();
    }
}