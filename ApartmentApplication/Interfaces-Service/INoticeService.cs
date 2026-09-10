using ApartmentApplication.DTOs.Notice;

namespace ApartmentApplication.Interfaces;

public interface INoticeService
{
    Task<IEnumerable<NoticeResponseDto>> GetAllAsync();

    Task<NoticeResponseDto?> GetByIdAsync(int id);

    Task<NoticeResponseDto> CreateAsync(
        CreateNoticeDto dto);

    Task<NoticeResponseDto?> UpdateAsync(
        int id,
        UpdateNoticeDto dto);

    Task<bool> DeleteAsync(int id);
}