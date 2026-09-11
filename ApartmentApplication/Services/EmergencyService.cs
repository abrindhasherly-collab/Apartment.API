using ApartmentDomain.Entities;
using ApartmentDomain.Enums;
using ApartmentDomain.Interfaces_Repository;
using ApartmentManagement.Application.DTOs.Emergency;
using ApartmentManagement.Application.Interfaces.Services;

using AutoMapper;

namespace ApartmentManagement.Application.Services;

public class EmergencyService : IEmergencyService
{
    private readonly IEmergencyRepository _repository;
    private readonly IMapper _mapper;

    public EmergencyService(IEmergencyRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmergencyDto>> GetAllAsync()
    {
        var emergencies = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<EmergencyDto>>(emergencies);
    }

    public async Task<EmergencyDto?> GetByIdAsync(int id)
    {
        var emergency = await _repository.GetByIdAsync(id);

        if (emergency == null)
            return null;

        return _mapper.Map<EmergencyDto>(emergency);
    }

    public async Task<EmergencyDto> CreateAsync(
        CreateEmergencyDto dto)
    {
        var emergency = _mapper.Map<EmergencyEntity>(dto);

        emergency.ReportedDate = DateTime.UtcNow;
        emergency.Status = EmergencyStatus.Reported;

        await _repository.AddAsync(emergency);

        return _mapper.Map<EmergencyDto>(emergency);
    }

    public async Task<EmergencyDto?> UpdateAsync(
        int id,
        UpdateEmergencyDto dto)
    {
        var existingEmergency = await _repository.GetByIdAsync(id);

        if (existingEmergency == null)
            return null;

        _mapper.Map(dto, existingEmergency);

        await _repository.UpdateAsync(existingEmergency);

        return _mapper.Map<EmergencyDto>(existingEmergency);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var emergency = await _repository.GetByIdAsync(id);

        if (emergency == null)
            return false;

        await _repository.DeleteAsync(id);

        return true;
    }
}