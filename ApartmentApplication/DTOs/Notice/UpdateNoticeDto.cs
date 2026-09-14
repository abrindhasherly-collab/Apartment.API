using ApartmentDomain.Enums;

namespace ApartmentApplication.DTOs.Notice;

public class UpdateNoticeDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public NoticeStatus Status { get; set; }
}