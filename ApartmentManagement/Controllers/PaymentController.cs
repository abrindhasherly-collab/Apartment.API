using ApartmentManagement.Application.DTOs.Payment;
using ApartmentManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // GET: api/Payment
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var payments = await _paymentService.GetAllAsync();

        return Ok(payments);
    }

    // GET: api/Payment/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await _paymentService.GetByIdAsync(id);

        if (payment == null)
        {
            return NotFound(new
            {
                message = "Payment record not found."
            });
        }

        return Ok(payment);
    }

    // POST: api/Payment
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePaymentDto dto)
    {
        try
        {
            var payment = await _paymentService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = payment.Id },
                payment);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    // PUT: api/Payment/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdatePaymentDto dto)
    {
        try
        {
            var payment = await _paymentService.UpdateAsync(id, dto);

            if (payment == null)
            {
                return NotFound(new
                {
                    message = "Payment record not found."
                });
            }

            return Ok(payment);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    // DELETE: api/Payment/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _paymentService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Payment record not found."
            });
        }

        return Ok(new
        {
            message = "Payment record deleted successfully."
        });
    }
}