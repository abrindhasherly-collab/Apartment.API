using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories;

public class NoticeRepository : INoticeRepository
{
    private readonly ApartmentDbcontext _context;

    public NoticeRepository(ApartmentDbcontext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notice>> GetAllAsync()
    {
        return await _context.Qwin9Notices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Notice?> GetByIdAsync(int id)
    {
        return await _context.Qwin9Notices
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Notice> AddAsync(Notice notice)
    {
        await _context.Qwin9Notices.AddAsync(notice);

        await _context.SaveChangesAsync();

        return notice;
    }

    public async Task UpdateAsync(Notice notice)
    {
        _context.Qwin9Notices.Update(notice);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var notice =
            await _context.Qwin9Notices
                .FirstOrDefaultAsync(x => x.Id == id);

        if (notice == null)
        {
            return;
        }

        _context.Qwin9Notices.Remove(notice);

        await _context.SaveChangesAsync();
    }
}