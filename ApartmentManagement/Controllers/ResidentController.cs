using ApartmentApplication.DTOs;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _residentService;

        public ResidentController(IResidentService residentService)
        {
            _residentService = residentService;
        }

        // GET: api/Resident
        [HttpGet]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<IActionResult> GetAll()
        {
            var residents = await _residentService.GetAllAsync();

            return Ok(residents);
        }

        // GET: api/Resident/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<IActionResult> GetById(int id)
        {
            var resident = await _residentService.GetByIdAsync(id);

            if (resident == null)
            {
                return NotFound(new
                {
                    message = "Resident not found."
                });
            }

            return Ok(resident);
        }

        // POST: api/Resident
        [HttpPost]
        [Authorize(Roles = "Secretary")]
        public async Task<IActionResult> Create(
            [FromBody] CreateResidentDto dto)
        {
            var resident = await _residentService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = resident.Id },
                resident);
        }

        // PUT: api/Resident/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateResidentDto dto)
        {
            var resident =
                await _residentService.UpdateAsync(id, dto);

            if (resident == null)
            {
                return NotFound(new
                {
                    message = "Resident not found."
                });
            }

            return Ok(resident);
        }

        // DELETE: api/Resident/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted =
                await _residentService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Resident not found."
                });
            }

            return Ok(new
            {
                message = "Resident deleted successfully."
            });
        }
    }
}