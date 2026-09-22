using ApartmentApplication.DTOs.FlatTransfer;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FlatTransferController : ControllerBase
    {
        private readonly IFlatTransferService _flatTransferService;

        public FlatTransferController(
            IFlatTransferService flatTransferService)
        {
            _flatTransferService = flatTransferService;
        }

        // GET: api/FlatTransfer
        [HttpGet]
        [Authorize(Roles = "Secretary,Resident,Owner")]
        public async Task<IActionResult> GetAll()
        {
            var transfers =
                await _flatTransferService.GetAllAsync();

            return Ok(transfers);
        }

        // GET: api/FlatTransfer/1
        [HttpGet("{id}")]
        [Authorize(Roles = "Secretary,Resident,Owner")]
        public async Task<IActionResult> GetById(int id)
        {
            var transfer =
                await _flatTransferService.GetByIdAsync(id);

            if (transfer == null)
                return NotFound();

            return Ok(transfer);
        }

        // POST: api/FlatTransfer
        [HttpPost]
        [Authorize(Roles = "Secretary,Resident,Owner")]
        public async Task<IActionResult> Create(
            CreateFlatTransferDto dto)
        {
            var transfer =
                await _flatTransferService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = transfer.Id },
                transfer);
        }

        // PUT: api/FlatTransfer/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<IActionResult> Update(
            int id,
            UpdateFlatTransferDto dto)
        {
            var result =
                await _flatTransferService.UpdateAsync(
                    id,
                    dto);

            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/FlatTransfer/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Secretary")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _flatTransferService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}