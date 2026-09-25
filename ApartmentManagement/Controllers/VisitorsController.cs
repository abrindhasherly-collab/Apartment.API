using ApartmentApplication.DTOs.Visitor;
using ApartmentApplication.Interfaces_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public VisitorsController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        // GET: api/Visitors
        [HttpGet]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<IActionResult> GetAll()
        {
            var visitors = await _visitorService.GetAllAsync();
            return Ok(visitors);
        }

        // GET: api/Visitors/1
        [HttpGet("{id}")]
        [Authorize(Roles = "Secretary,Resident,Watchman,Owner")]
        public async Task<IActionResult> GetById(int id)
        {
            var visitor = await _visitorService.GetByIdAsync(id);

            if (visitor == null)
                return NotFound();

            return Ok(visitor);
        }

        // POST: api/Visitors
        [HttpPost]
        [Authorize(Roles = "Secretary,Resident,Watchman")]
        public async Task<IActionResult> Create(CreateVisitorDto dto)
        {
            var visitor = await _visitorService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = visitor.Id },
                visitor);
        }

        // PUT: api/Visitors/1
        [HttpPut("{id}")]
        [Authorize(Roles = "Secretary,Watchman")]
        public async Task<IActionResult> Update(int id, UpdateVisitorDto dto)
        {
            var result = await _visitorService.UpdateAsync(id, dto);

            if (!result)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Visitors/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Secretary,Watchman")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _visitorService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}