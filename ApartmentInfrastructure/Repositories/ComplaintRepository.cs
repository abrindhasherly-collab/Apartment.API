using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces_Repository;
using ApartmentInfrastructure.Data;

using Microsoft.EntityFrameworkCore;
using System;

namespace ApartmentManagement.Infrastructure.Repositories;

public class ComplaintRepository : IComplaintRepository
{
    private readonly ApartmentDbcontext _context;

    public ComplaintRepository(ApartmentDbcontext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ComplaintEntity>> GetAllAsync()
    {
        return await _context.Complaints
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ComplaintEntity?> GetByIdAsync(int id)
    {
        return await _context.Complaints
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(ComplaintEntity complaint)
    {
        await _context.Complaints.AddAsync(complaint);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ComplaintEntity complaint)
    {
        _context.Complaints.Update(complaint);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var complaint = await _context.Complaints
            .FirstOrDefaultAsync(c => c.Id == id);

        if (complaint != null)
        {
            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();
        }
    }
}

