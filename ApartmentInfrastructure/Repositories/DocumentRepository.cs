using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using ApartmentInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly ApartmentDbContext _context;

    public DocumentRepository(ApartmentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Document>> GetAllAsync()
    {
        return await _context.Documents
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Document?> GetByIdAsync(int id)
    {
        return await _context.Documents
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Document> AddAsync(Document document)
    {
        await _context.Documents.AddAsync(document);

        await _context.SaveChangesAsync();

        return document;
    }

    public async Task UpdateAsync(Document document)
    {
        _context.Documents.Update(document);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var document =
            await _context.Documents
                .FirstOrDefaultAsync(x => x.Id == id);

        if (document == null)
        {
            return;
        }

        _context.Documents.Remove(document);

        await _context.SaveChangesAsync();
    }
}