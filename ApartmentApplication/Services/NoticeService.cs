using ApartmentApplication.DTOs.Notice;
using ApartmentApplication.Interfaces;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using AutoMapper;

namespace ApartmentApplication.Services;

public class NoticeService : INoticeService
{
    private readonly INoticeRepository _repository;
    private readonly IMapper _mapper;

    public NoticeService(
        INoticeRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NoticeResponseDto>> GetAllAsync()
    {
        var notices = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<NoticeResponseDto>>(
            notices);
    }

    public async Task<NoticeResponseDto?> GetByIdAsync(int id)
    {
        var notice =
            await _repository.GetByIdAsync(id);

        if (notice == null)
        {
            return null;
        }

        return _mapper.Map<NoticeResponseDto>(notice);
    }

    public async Task<NoticeResponseDto> CreateAsync(
        CreateNoticeDto dto)
    {
        var notice = _mapper.Map<Notice>(dto);

        notice.PostedDate = DateTime.UtcNow;

        var result =
            await _repository.AddAsync(notice);

        return _mapper.Map<NoticeResponseDto>(result);
    }

    public async Task<NoticeResponseDto?> UpdateAsync(
        int id,
        UpdateNoticeDto dto)
    {
        var notice =
            await _repository.GetByIdAsync(id);

        if (notice == null)
        {
            return null;
        }

        _mapper.Map(dto, notice);

        await _repository.UpdateAsync(notice);

        return _mapper.Map<NoticeResponseDto>(notice);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var notice =
            await _repository.GetByIdAsync(id);

        if (notice == null)
        {
            return false;
        }

        await _repository.DeleteAsync(id);

        return true;
    }
}