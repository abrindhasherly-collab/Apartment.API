using ApartmentApplication.DTOs.Document;
using ApartmentApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentsController(
        IDocumentService documentService)
    {
        _documentService = documentService;
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
        {
            return NotFound("Document not found.");
        }

        return Ok(document);
    }

    [HttpPost]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Create(
        CreateDocumentDto dto)
    {
        var document =
            await _documentService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = document.Id },
            document);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Update(
        int id,
        UpdateDocumentDto dto)
    {
        var document =
            await _documentService.UpdateAsync(
                id,
                dto);

        if (document == null)
        {
            return NotFound("Document not found.");
        }

        return Ok(document);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _documentService.DeleteAsync(id);

        if (!result)
        {
            return NotFound("Document not found.");
        }

        return Ok(new
        {
            message = "Document deleted successfully."
        });
    }
}