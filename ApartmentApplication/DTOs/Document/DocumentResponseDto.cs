using ApartmentDomain.Enums;

namespace ApartmentApplication.DTOs.Document;

public class DocumentResponseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public DateTime UploadedDate { get; set; }

    public int UploadedBy { get; set; }

    public DocumentStatus Status { get; set; }
}