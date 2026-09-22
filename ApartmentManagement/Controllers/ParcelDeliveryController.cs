using ApartmentApplication.DTOs.ParcelDelivery;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ParcelDeliveryController : ControllerBase
    {
        private readonly IParcelDeliveryService _parcelDeliveryService;

        public ParcelDeliveryController(IParcelDeliveryService parcelDeliveryService)
        {
            _parcelDeliveryService = parcelDeliveryService;
        }

        // GET: api/ParcelDelivery
        [HttpGet]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<IActionResult> GetAll()
        {
            var deliveries = await _parcelDeliveryService.GetAllAsync();
            return Ok(deliveries);
        }

        // GET: api/ParcelDelivery/1
        [HttpGet("{id}")]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<IActionResult> GetById(int id)
        {
            var delivery = await _parcelDeliveryService.GetByIdAsync(id);

            if (delivery == null)
                return NotFound();

            return Ok(delivery);
        }

        // POST: api/ParcelDelivery
        [HttpPost]
        [Authorize(Roles = "Secretary,Resident,Watchman")]
        public async Task<IActionResult> Create(CreateParcelDeliveryDto dto)
        {
            var delivery = await _parcelDeliveryService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = delivery.Id },
                delivery);
        }

        // PUT: api/ParcelDelivery/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Secretary,Watchman")]
        public async Task<IActionResult> Update(
            int id,
            UpdateParcelDeliveryDto dto)
        {
            var result = await _parcelDeliveryService.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/ParcelDelivery/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Secretary,Watchman")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _parcelDeliveryService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}