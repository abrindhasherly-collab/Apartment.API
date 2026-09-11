using ApartmentDomain.Entities;
using ApartmentDomain.Enums;
using ApartmentDomain.Interfaces_Repository;
using ApartmentManagement.Application.DTOs.Complaint;
using ApartmentManagement.Application.Interfaces.Services;

using AutoMapper;

namespace ApartmentManagement.Application.Services;

public class ComplaintService : IComplaintService
{
    private readonly IComplaintRepository _repository;
    private readonly IMapper _mapper;


    public ComplaintService(
        IComplaintRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ComplaintDto>> GetAllAsync()
    {
        var complaints = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<ComplaintDto>>(complaints);
    }

    public async Task<ComplaintDto?> GetByIdAsync(int id)
    {
        var complaint = await _repository.GetByIdAsync(id);

        if (complaint == null)
            return null;

        return _mapper.Map<ComplaintDto>(complaint);
    }

    public async Task<ComplaintDto> CreateAsync(
        CreateComplaintDto dto)
    {
        var complaint = _mapper.Map<ComplaintEntity>(dto);

        complaint.ComplaintDate = DateTime.UtcNow;
        complaint.Status = ComplaintStatus.Pending;

        await _repository.AddAsync(complaint);

        return _mapper.Map<ComplaintDto>(complaint);
    }

    public async Task<ComplaintDto?> UpdateAsync(
        int id,
        UpdateComplaintDto dto)
    {
        var existingComplaint = await _repository.GetByIdAsync(id);

        if (existingComplaint == null)
            return null;

        _mapper.Map(dto, existingComplaint);

        await _repository.UpdateAsync(existingComplaint);

        return _mapper.Map<ComplaintDto>(existingComplaint);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var complaint = await _repository.GetByIdAsync(id);

        if (complaint == null)
            return false;

        await _repository.DeleteAsync(id);

        return true;
    }
}