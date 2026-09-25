using ApartmentApplication.DTOs.Maintenance;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(
            IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        // GET: api/Maintenance
        [HttpGet]
        [Authorize(Roles = "Secretary,Resident,Owner")]
        public async Task<ActionResult<IEnumerable<MaintenanceResponseDto>>> GetAll()
        {
            var maintenance =
                await _maintenanceService.GetAllAsync();

            return Ok(maintenance);
        }

        // GET: api/Maintenance/1
        [HttpGet("{id}")]
        [Authorize(Roles = "Secretary,Resident,Owner")]
        public async Task<ActionResult<MaintenanceResponseDto>> GetById(int id)
        {
            var maintenance =
                await _maintenanceService.GetByIdAsync(id);

            if (maintenance == null)
            {
                return NotFound(new
                {
                    message = "Maintenance record not found."
                });
            }

            return Ok(maintenance);
        }

        // POST: api/Maintenance
        [HttpPost]
        [Authorize(Roles = "Secretary")]
        public async Task<ActionResult<MaintenanceResponseDto>> Create(
            MaintenanceCreateDto dto)
        {
            var maintenance =
                await _maintenanceService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = maintenance.Id },
                maintenance);
        }

        // PUT: api/Maintenance/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<ActionResult<MaintenanceResponseDto>> Update(
            int id,
            MaintenanceUpdateDto dto)
        {
            var maintenance =
                await _maintenanceService.UpdateAsync(
                    id,
                    dto);

            if (maintenance == null)
            {
                return NotFound(new
                {
                    message = "Maintenance record not found."
                });
            }

            return Ok(maintenance);
        }

        // DELETE: api/Maintenance/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted =
                await _maintenanceService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Maintenance record not found."
                });
            }

            return NoContent();
        }
    }
}