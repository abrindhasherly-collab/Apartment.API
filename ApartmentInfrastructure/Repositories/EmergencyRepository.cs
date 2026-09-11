using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.Infrastructure.Repositories;

public class EmergencyRepository : IEmergencyRepository
{
    private readonly ApartmentDbcontext _context;

    public EmergencyRepository(ApartmentDbcontext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmergencyEntity>> GetAllAsync()
    {
        return await _context.Emergencies
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<EmergencyEntity?> GetByIdAsync(int id)
    {
        return await _context.Emergencies
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(EmergencyEntity emergency)
    {
        await _context.Emergencies.AddAsync(emergency);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EmergencyEntity emergency)
    {
        _context.Emergencies.Update(emergency);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var emergency = await _context.Emergencies
            .FirstOrDefaultAsync(e => e.Id == id);

        if (emergency != null)
        {
            _context.Emergencies.Remove(emergency);
            await _context.SaveChangesAsync();
        }
    }
}