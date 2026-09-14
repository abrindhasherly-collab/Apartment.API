using ApartmentDomain.Entities;
using ApartmentDomain.Enums;
using ApartmentDomain.Interfaces_Repository;
using ApartmentManagement.Application.DTOs.Payment;
using ApartmentManagement.Application.Interfaces.Services;

using AutoMapper;

namespace ApartmentManagement.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public PaymentService(
        IPaymentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymentDto>> GetAllAsync()
    {
        var payments = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<PaymentDto>>(payments);
    }

    public async Task<PaymentDto?> GetByIdAsync(int id)
    {
        var payment = await _repository.GetByIdAsync(id);

        if (payment == null)
            return null;

        return _mapper.Map<PaymentDto>(payment);
    }

    public async Task<PaymentDto> CreateAsync(
        CreatePaymentDto dto)
    {
        var payment = _mapper.Map<PaymentEntity>(dto);

        payment.Status = PaymentStatus.Success;

        await _repository.AddAsync(payment);

        return _mapper.Map<PaymentDto>(payment);
    }

    public async Task<PaymentDto?> UpdateAsync(
        int id,
        UpdatePaymentDto dto)
    {
        var existingPayment = await _repository.GetByIdAsync(id);

        if (existingPayment == null)
            return null;

        _mapper.Map(dto, existingPayment);

        await _repository.UpdateAsync(existingPayment);

        return _mapper.Map<PaymentDto>(existingPayment);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var payment = await _repository.GetByIdAsync(id);

        if (payment == null)
            return false;

        await _repository.DeleteAsync(id);

        return true;
    }
}