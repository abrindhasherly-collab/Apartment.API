using ApartmentManagement.Application.DTOs.Complaint;

namespace ApartmentManagement.Application.Interfaces.Services;

public interface IComplaintService
{
    Task<IEnumerable<ComplaintDto>> GetAllAsync();

    Task<ComplaintDto?> GetByIdAsync(int id);

    Task<ComplaintDto> CreateAsync(CreateComplaintDto dto);

    Task<ComplaintDto?> UpdateAsync(int id, UpdateComplaintDto dto);

    Task<bool> DeleteAsync(int id);
}