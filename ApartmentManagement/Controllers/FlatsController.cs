using ApartmentApplication.DTOs.Flat;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        private readonly IFlatService _flatService;

        public FlatsController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        // GET: api/Flats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlatResponseDto>>> GetAll()
        {
            var flats = await _flatService.GetAllAsync();

            return Ok(flats);
        }

        // GET: api/Flats/1
        [HttpGet("{id}")]
        public async Task<ActionResult<FlatResponseDto>> GetById(int id)
        {
            var flat = await _flatService.GetByIdAsync(id);

            if (flat == null)
            {
                return NotFound(new
                {
                    message = "Flat not found."
                });
            }

            return Ok(flat);
        }

        // POST: api/Flats
        [HttpPost]
        public async Task<ActionResult<FlatResponseDto>> Create(
            FlatCreateDto dto)
        {
            var flat = await _flatService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = flat.Id },
                flat);
        }

        // PUT: api/Flats/1
        [HttpPut("{id}")]
        public async Task<ActionResult<FlatResponseDto>> Update(
            int id,
            FlatUpdateDto dto)
        {
            var flat = await _flatService.UpdateAsync(id, dto);

            if (flat == null)
            {
                return NotFound(new
                {
                    message = "Flat not found."
                });
            }

            return Ok(flat);
        }

        // DELETE: api/Flats/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _flatService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Flat not found."
                });
            }

            return NoContent();
        }
    }
}
