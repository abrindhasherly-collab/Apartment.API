using ApartmentManagement.Application.DTOs.Payment;

namespace ApartmentManagement.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetAllAsync();

    Task<PaymentDto?> GetByIdAsync(int id);

    Task<PaymentDto> CreateAsync(CreatePaymentDto dto);

    Task<PaymentDto?> UpdateAsync(int id, UpdatePaymentDto dto);

    Task<bool> DeleteAsync(int id);
}