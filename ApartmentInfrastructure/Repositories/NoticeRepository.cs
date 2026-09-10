using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories;

public class NoticeRepository : INoticeRepository
{
    private readonly ApartmentDbContext _context;

    public NoticeRepository(ApartmentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notice>> GetAllAsync()
    {
        return await _context.Notices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Notice?> GetByIdAsync(int id)
    {
        return await _context.Notices
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Notice> AddAsync(Notice notice)
    {
        await _context.Notices.AddAsync(notice);

        await _context.SaveChangesAsync();

        return notice;
    }

    public async Task UpdateAsync(Notice notice)
    {
        _context.Notices.Update(notice);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var notice =
            await _context.Notices
                .FirstOrDefaultAsync(x => x.Id == id);

        if (notice == null)
        {
            return;
        }

        _context.Notices.Remove(notice);

        await _context.SaveChangesAsync();
    }
}