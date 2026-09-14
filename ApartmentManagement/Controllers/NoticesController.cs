using ApartmentApplication.DTOs.Notice;
using ApartmentApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NoticesController : ControllerBase
{
    private readonly INoticeService _noticeService;

    public NoticesController(INoticeService noticeService)
    {
        _noticeService = noticeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notices =
            await _noticeService.GetAllAsync();

        return Ok(notices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var notice =
            await _noticeService.GetByIdAsync(id);

        if (notice == null)
        {
            return NotFound("Notice not found.");
        }

        return Ok(notice);
    }

    [HttpPost]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Create(
        CreateNoticeDto dto)
    {
        var notice =
            await _noticeService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = notice.Id },
            notice);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Update(
        int id,
        UpdateNoticeDto dto)
    {
        var notice =
            await _noticeService.UpdateAsync(
                id,
                dto);

        if (notice == null)
        {
            return NotFound("Notice not found.");
        }

        return Ok(notice);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _noticeService.DeleteAsync(id);

        if (!result)
        {
            return NotFound("Notice not found.");
        }

        return Ok(new
        {
            message = "Notice deleted successfully."
        });
    }
}