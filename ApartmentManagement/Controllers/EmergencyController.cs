using ApartmentManagement.Application.DTOs.Emergency;
using ApartmentManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmergencyController : ControllerBase
{
    private readonly IEmergencyService _emergencyService;

    public EmergencyController(IEmergencyService emergencyService)
    {
        _emergencyService = emergencyService;
    }

    // GET: api/Emergency
    [HttpGet]
    [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
    public async Task<IActionResult> GetAll()
    {
        var emergencies = await _emergencyService.GetAllAsync();

        return Ok(emergencies);
    }

    // GET: api/Emergency/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
    public async Task<IActionResult> GetById(int id)
    {
        var emergency = await _emergencyService.GetByIdAsync(id);

        if (emergency == null)
        {
            return NotFound(new
            {
                message = "Emergency record not found."
            });
        }

        return Ok(emergency);
    }

    // POST: api/Emergency
    [HttpPost]
    [Authorize(Roles = "Secretary,Resident")]
    public async Task<IActionResult> Create(
        [FromBody] CreateEmergencyDto dto)
    {
        var emergency = await _emergencyService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = emergency.Id },
            emergency);
    }

    // PUT: api/Emergency/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateEmergencyDto dto)
    {
        var emergency = await _emergencyService.UpdateAsync(id, dto);

        if (emergency == null)
        {
            return NotFound(new
            {
                message = "Emergency not found."
            });
        }

        return Ok(emergency);
    }

    // DELETE: api/Emergency/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _emergencyService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Emergency not found."
            });
        }

        return Ok(new
        {
            message = "Emergency deleted successfully."
        });
    }
}