using ApartmentManagement.Application.DTOs.Complaint;
using ApartmentManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ComplaintController : ControllerBase
{
    private readonly IComplaintService _complaintService;

    public ComplaintController(
        IComplaintService complaintService)
    {
        _complaintService = complaintService;
    }

    // GET: api/Complaint
    [HttpGet]
    [Authorize(Roles = "Secretary,Resident,Owner")]
    public async Task<IActionResult> GetAll()
    {
        var complaints =
            await _complaintService.GetAllAsync();

        return Ok(complaints);
    }

    // GET: api/Complaint/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Secretary,Resident,Owner")]
    public async Task<IActionResult> GetById(int id)
    {
        var complaint =
            await _complaintService.GetByIdAsync(id);

        if (complaint == null)
        {
            return NotFound(new
            {
                message = "Complaint not found."
            });
        }

        return Ok(complaint);
    }

    // POST: api/Complaint
    [HttpPost]
    [Authorize(Roles = "Secretary,Resident")]
    public async Task<IActionResult> Create(
        [FromBody] CreateComplaintDto dto)
    {
        var complaint =
            await _complaintService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = complaint.Id },
            complaint);
    }

    // PUT: api/Complaint/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateComplaintDto dto)
    {
        var complaint =
            await _complaintService.UpdateAsync(id, dto);

        if (complaint == null)
        {
            return NotFound(new
            {
                message = "Complaint not found."
            });
        }

        return Ok(complaint);
    }

    // DELETE: api/Complaint/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted =
            await _complaintService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Complaint not found."
            });
        }

        return Ok(new
        {
            message = "Complaint deleted successfully."
        });
    }
}