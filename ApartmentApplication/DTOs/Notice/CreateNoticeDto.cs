using ApartmentDomain.Enums;

namespace ApartmentApplication.DTOs.Notice;

public class CreateNoticeDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int PostedBy { get; set; }

    public NoticeStatus Status { get; set; } = NoticeStatus.Published;
}