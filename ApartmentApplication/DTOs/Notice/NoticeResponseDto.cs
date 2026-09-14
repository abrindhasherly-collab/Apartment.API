using ApartmentDomain.Enums;

namespace ApartmentApplication.DTOs.Notice;

public class NoticeResponseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime PostedDate { get; set; }

    public int PostedBy { get; set; }

    public NoticeStatus Status { get; set; }
}