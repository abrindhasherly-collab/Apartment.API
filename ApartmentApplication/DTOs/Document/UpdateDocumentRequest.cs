using ApartmentDomain.Enums;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Models;

public class UpdateDocumentRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DocumentStatus Status { get; set; }

    public IFormFile? File { get; set; }
}