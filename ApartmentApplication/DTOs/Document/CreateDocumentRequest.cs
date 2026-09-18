using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Models;

public class CreateDocumentRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile? File { get; set; }

    public int UploadedBy { get; set; }
}