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
        return await _context.Qwin9Emergencies
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<EmergencyEntity?> GetByIdAsync(int id)
    {
        return await _context.Qwin9Emergencies
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(EmergencyEntity emergency)
    {
        await _context.Qwin9Emergencies.AddAsync(emergency);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EmergencyEntity emergency)
    {
        _context.Qwin9Emergencies.Update(emergency);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var emergency = await _context.Qwin9Emergencies
            .FirstOrDefaultAsync(e => e.Id == id);

        if (emergency != null)
        {
            _context.Qwin9Emergencies.Remove(emergency);
            await _context.SaveChangesAsync();
        }
    }
}