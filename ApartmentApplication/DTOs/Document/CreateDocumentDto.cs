namespace ApartmentApplication.DTOs.Document;

public class CreateDocumentDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public int UploadedBy { get; set; }
}