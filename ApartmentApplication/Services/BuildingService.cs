using ApartmentApplication.DTOs.Building;
using ApartmentApplication.Interfaces;
using ApartmentDomain.Entities;
using ApartmentDomain.Interfaces;
using AutoMapper;

namespace ApartmentApplication.Services;

public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _repository;
    private readonly IMapper _mapper;

    public BuildingService(
        IBuildingRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BuildingResponseDto>> GetAllAsync()
    {
        var buildings = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<BuildingResponseDto>>(
            buildings);
    }

    public async Task<BuildingResponseDto?> GetByIdAsync(int id)
    {
        var building = await _repository.GetByIdAsync(id);

        if (building == null)
        {
            return null;
        }

        return _mapper.Map<BuildingResponseDto>(building);
    }

    public async Task<BuildingResponseDto> CreateAsync(
        CreateBuildingDto dto)
    {
        var building = _mapper.Map<Building>(dto);

        var result =
            await _repository.AddAsync(building);

        return _mapper.Map<BuildingResponseDto>(result);
    }

    public async Task<BuildingResponseDto?> UpdateAsync(
        int id,
        UpdateBuildingDto dto)
    {
        var building =
            await _repository.GetByIdAsync(id);

        if (building == null)
        {
            return null;
        }

        _mapper.Map(dto, building);

        await _repository.UpdateAsync(building);

        return _mapper.Map<BuildingResponseDto>(building);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var building =
            await _repository.GetByIdAsync(id);

        if (building == null)
        {
            return false;
        }

        await _repository.DeleteAsync(id);

        return true;
    }
}