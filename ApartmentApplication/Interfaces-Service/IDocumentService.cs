using ApartmentApplication.DTOs.Document;

namespace ApartmentApplication.Interfaces;

public interface IDocumentService
{
    Task<IEnumerable<DocumentResponseDto>> GetAllAsync();

    Task<DocumentResponseDto?> GetByIdAsync(int id);

    Task<DocumentResponseDto> CreateAsync(
        CreateDocumentDto dto);

    Task<DocumentResponseDto?> UpdateAsync(
        int id,
        UpdateDocumentDto dto);

    Task<bool> DeleteAsync(int id);
}