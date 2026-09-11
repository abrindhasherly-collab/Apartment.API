using ApartmentManagement.Application.DTOs.Emergency;

namespace ApartmentManagement.Application.Interfaces.Services;

public interface IEmergencyService
{
    Task<IEnumerable<EmergencyDto>> GetAllAsync();

    Task<EmergencyDto?> GetByIdAsync(int id);

    Task<EmergencyDto> CreateAsync(CreateEmergencyDto dto);

    Task<EmergencyDto?> UpdateAsync(int id, UpdateEmergencyDto dto);

    Task<bool> DeleteAsync(int id);
}