using ApartmentDomain.Entities;

namespace ApartmentDomain.Interfaces;

public interface IBuildingRepository
{
    Task<IEnumerable<Building>> GetAllAsync();

    Task<Building?> GetByIdAsync(int id);

    Task<Building> AddAsync(Building building);

    Task UpdateAsync(Building building);

    Task DeleteAsync(int id);
}