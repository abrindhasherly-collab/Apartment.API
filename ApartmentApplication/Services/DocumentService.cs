using ApartmentApplication.DTOs.Document;
using ApartmentApplication.Interfaces;
using ApartmentDomain.Entities;
using ApartmentDomain.Enums;
using ApartmentDomain.Interfaces;
using AutoMapper;

namespace ApartmentApplication.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _repository;
    private readonly IMapper _mapper;

    public DocumentService(
        IDocumentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DocumentResponseDto>> GetAllAsync()
    {
        var documents = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<DocumentResponseDto>>(
            documents);
    }

    public async Task<DocumentResponseDto?> GetByIdAsync(int id)
    {
        var document =
            await _repository.GetByIdAsync(id);

        if (document == null)
        {
            return null;
        }

        return _mapper.Map<DocumentResponseDto>(document);
    }

    public async Task<DocumentResponseDto> CreateAsync(
        CreateDocumentDto dto)
    {
        var document =
            _mapper.Map<Document>(dto);

        document.UploadedDate = DateTime.UtcNow;
        document.Status = DocumentStatus.Active;

        var result =
            await _repository.AddAsync(document);

        return _mapper.Map<DocumentResponseDto>(result);
    }

    public async Task<DocumentResponseDto?> UpdateAsync(
        int id,
        UpdateDocumentDto dto)
    {
        var document =
            await _repository.GetByIdAsync(id);

        if (document == null)
        {
            return null;
        }

        _mapper.Map(dto, document);

        await _repository.UpdateAsync(document);

        return _mapper.Map<DocumentResponseDto>(document);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var document =
            await _repository.GetByIdAsync(id);

        if (document == null)
        {
            return false;
        }

        await _repository.DeleteAsync(id);

        return true;
    }
}