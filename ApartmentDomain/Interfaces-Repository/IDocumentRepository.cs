using ApartmentDomain.Entities;

namespace ApartmentDomain.Interfaces;

public interface IDocumentRepository
{
    Task<IEnumerable<Document>> GetAllAsync();

    Task<Document?> GetByIdAsync(int id);

    Task<Document> AddAsync(Document document);

    Task UpdateAsync(Document document);

    Task DeleteAsync(int id);
}