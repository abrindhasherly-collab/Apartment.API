using ApartmentDomain.Enums;

namespace ApartmentApplication.DTOs.Document;

public class UpdateDocumentDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public DocumentStatus Status { get; set; }
}