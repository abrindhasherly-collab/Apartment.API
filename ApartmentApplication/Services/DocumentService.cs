using ApartmentApplication.DTOs.Document;
using ApartmentApplication.Interfaces;
using ApartmentDomain.Entities;
using ApartmentDomain.Enums;
using ApartmentDomain.Interfaces;
using AutoMapper;

namespace ApartmentApplication.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IMapper _mapper;

    public DocumentService(
        IDocumentRepository documentRepository,
        IMapper mapper)
    {
        _documentRepository = documentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DocumentResponseDto>> GetAllAsync()
    {
        var documents = await _documentRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<DocumentResponseDto>>(documents);
    }

    public async Task<DocumentResponseDto?> GetByIdAsync(int id)
    {
        var document = await _documentRepository.GetByIdAsync(id);

        if (document == null)
            return null;

        return _mapper.Map<DocumentResponseDto>(document);
    }

    public async Task<DocumentResponseDto> CreateAsync(
        CreateDocumentDto dto)
    {
        var document = new Document
        {
            Title = dto.Title,
            Description = dto.Description,
            FileName = dto.FileName,
            FilePath = dto.FilePath,
            UploadedBy = dto.UploadedBy,
            UploadedDate = DateTime.UtcNow,
            Status = DocumentStatus.Active
        };

        var createdDocument =
            await _documentRepository.AddAsync(document);

        return _mapper.Map<DocumentResponseDto>(
            createdDocument);
    }

    public async Task<DocumentResponseDto?> UpdateAsync(
        int id,
        UpdateDocumentDto dto)
    {
        var document =
            await _documentRepository.GetByIdAsync(id);

        if (document == null)
            return null;

        document.Title = dto.Title;
        document.Description = dto.Description;
        document.Status = dto.Status;

        // Update file only if a new file was selected
        if (!string.IsNullOrEmpty(dto.FileName))
        {
            document.FileName = dto.FileName;
            document.FilePath = dto.FilePath;
        }

        await _documentRepository.UpdateAsync(document);

        return _mapper.Map<DocumentResponseDto>(
            document);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var document =
            await _documentRepository.GetByIdAsync(id);

        if (document == null)
            return false;

        await _documentRepository.DeleteAsync(id);

        return true;
    }
}