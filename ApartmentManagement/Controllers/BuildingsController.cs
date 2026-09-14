using ApartmentApplication.DTOs.Building;
using ApartmentApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BuildingsController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingsController(
        IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var buildings =
            await _buildingService.GetAllAsync();

        return Ok(buildings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var building =
            await _buildingService.GetByIdAsync(id);

        if (building == null)
        {
            return NotFound("Building not found.");
        }

        return Ok(building);
    }

    [HttpPost]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Create(
        CreateBuildingDto dto)
    {
        var building =
            await _buildingService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = building.Id },
            building);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Update(
        int id,
        UpdateBuildingDto dto)
    {
        var building =
            await _buildingService.UpdateAsync(
                id,
                dto);

        if (building == null)
        {
            return NotFound("Building not found.");
        }

        return Ok(building);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Secretary")]
    public async Task<IActionResult> Delete(int id)
    {
        var result =
            await _buildingService.DeleteAsync(id);

        if (!result)
        {
            return NotFound("Building not found.");
        }

        return Ok(new
        {
            message = "Building deleted successfully."
        });
    }
}