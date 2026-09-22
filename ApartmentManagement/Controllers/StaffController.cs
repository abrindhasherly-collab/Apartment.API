using ApartmentApplication.DTOs.Staff;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: api/Staff
        [HttpGet]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<ActionResult<IEnumerable<StaffResponseDto>>> GetAll()
        {
            var staff = await _staffService.GetAllAsync();

            return Ok(staff);
        }

        // GET: api/Staff/1
        [HttpGet("{id}")]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<ActionResult<StaffResponseDto>> GetById(int id)
        {
            var staff = await _staffService.GetByIdAsync(id);

            if (staff == null)
            {
                return NotFound(new
                {
                    message = "Staff member not found."
                });
            }

            return Ok(staff);
        }

        // POST: api/Staff
        [HttpPost]
        [Authorize(Roles = "Secretary")]
        public async Task<ActionResult<StaffResponseDto>> Create(
            StaffCreateDto dto)
        {
            var staff = await _staffService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = staff.Id },
                staff);
        }

        // PUT: api/Staff/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<ActionResult<StaffResponseDto>> Update(
            int id,
            StaffUpdateDto dto)
        {
            var staff = await _staffService.UpdateAsync(id, dto);

            if (staff == null)
            {
                return NotFound(new
                {
                    message = "Staff member not found."
                });
            }

            return Ok(staff);
        }

        // DELETE: api/Staff/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _staffService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Staff member not found."
                });
            }

            return NoContent();
        }
    }
}