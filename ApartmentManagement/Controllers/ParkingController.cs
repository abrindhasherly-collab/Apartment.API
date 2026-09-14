using ApartmentApplication.DTOs.Parking;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        // GET: api/Parking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingResponseDto>>> GetAll()
        {
            var parking = await _parkingService.GetAllAsync();

            return Ok(parking);
        }

        // GET: api/Parking/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingResponseDto>> GetById(int id)
        {
            var parking = await _parkingService.GetByIdAsync(id);

            if (parking == null)
            {
                return NotFound(new
                {
                    message = "Parking record not found."
                });
            }

            return Ok(parking);
        }

        // POST: api/Parking
        [HttpPost]
        public async Task<ActionResult<ParkingResponseDto>> Create(
            ParkingCreateDto dto)
        {
            var parking = await _parkingService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = parking.Id },
                parking);
        }

        // PUT: api/Parking/1
        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingResponseDto>> Update(
            int id,
            ParkingUpdateDto dto)
        {
            var parking = await _parkingService.UpdateAsync(id, dto);

            if (parking == null)
            {
                return NotFound(new
                {
                    message = "Parking record not found."
                });
            }

            return Ok(parking);
        }

        // DELETE: api/Parking/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _parkingService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Parking record not found."
                });
            }

            return NoContent();
        }
    }
}
