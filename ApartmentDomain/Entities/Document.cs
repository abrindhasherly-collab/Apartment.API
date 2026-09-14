using ApartmentDomain.Enums;

namespace ApartmentDomain.Entities;

public class Document
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

    public int UploadedBy { get; set; }

    public DocumentStatus Status { get; set; }
}