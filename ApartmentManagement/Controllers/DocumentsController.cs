using ApartmentApplication.DTOs.Document;
using ApartmentApplication.Interfaces;
using ApartmentManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;
    private readonly IWebHostEnvironment _environment;

    public DocumentsController(
        IDocumentService documentService,
        IWebHostEnvironment environment)
    {
        _documentService = documentService;
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var documents =
            await _documentService.GetAllAsync();

        return Ok(documents);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var document =
            await _documentService.GetByIdAsync(id);

        if (document == null)
            return NotFound();

        return Ok(document);
    }

    [HttpPost]
    [Authorize(Roles = "Secretary")]
    [RequestSizeLimit(10 * 1024 * 1024)]
    public async Task<IActionResult> Create(
        [FromForm] CreateDocumentRequest request)
    {
        if (request.File == null)
            return BadRequest("PDF file is required.");

        if (Path.GetExtension(request.File.FileName)
            .ToLower() != ".pdf")
        {
            return BadRequest("Only PDF files are allowed.");
        }

        var folderPath = Path.Combine(
            _environment.WebRootPath,
            "documents");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var savedFileName =
            Guid.NewGuid().ToString()
            + ".pdf";

        var physicalPath = Path.Combine(
            folderPath,
            savedFileName);

        using (var stream = new FileStream(
            physicalPath,
            FileMode.Create))
        {
            await request.File.CopyToAsync(stream);
        }

        var dto = new CreateDocumentDto
        {
            Title = request.Title,
            Description = request.Description,
            FileName = request.File.FileName,
            FilePath = "/documents/" + savedFileName,
            UploadedBy = request.UploadedBy
        };

        var document =
            await _documentService.CreateAsync(dto);

        return Ok(document);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Secretary")]
    [RequestSizeLimit(10 * 1024 * 1024)]
    public async Task<IActionResult> Update(
        int id,
        [FromForm] UpdateDocumentRequest request)
    {
        if (request.File != null &&
            Path.GetExtension(request.File.FileName)
                .ToLower() != ".pdf")
        {
            return BadRequest("Only PDF files are allowed.");
        }

        string fileName = string.Empty;
        string filePath = string.Empty;

        if (request.File != null)
        {
            var folderPath = Path.Combine(
                _environment.WebRootPath,
                "documents");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var savedFileName =
                Guid.NewGuid().ToString()
                + ".pdf";

            var physicalPath = Path.Combine(
                folderPath,
                savedFileName);

            using (var stream = new FileStream(
                physicalPath,
                FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            fileName = request.File.FileName;
            filePath = "/documents/" + savedFileName;
        }

        var dto = new UpdateDocumentDto
        {
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            FileName = fileName,
            FilePath = filePath
        };

        var document =
            await _documentService.UpdateAsync(id, dto);

        if (document == null)
            return NotFound();

        return Ok(document);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _documentService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}