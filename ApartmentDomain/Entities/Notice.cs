using ApartmentDomain.Enums;

namespace ApartmentDomain.Entities;

public class Notice
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime PostedDate { get; set; } = DateTime.UtcNow;

    public int PostedBy { get; set; }

    public NoticeStatus Status { get; set; }
}