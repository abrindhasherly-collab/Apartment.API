using ApartmentApplication.DTOs.Building;

namespace ApartmentApplication.Interfaces;

public interface IBuildingService
{
    Task<IEnumerable<BuildingResponseDto>> GetAllAsync();

    Task<BuildingResponseDto?> GetByIdAsync(int id);

    Task<BuildingResponseDto> CreateAsync(
        CreateBuildingDto dto);

    Task<BuildingResponseDto?> UpdateAsync(
        int id,
        UpdateBuildingDto dto);

    Task<bool> DeleteAsync(int id);
}