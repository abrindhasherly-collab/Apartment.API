using ApartmentApplication.DTOs.Visitor;

namespace ApartmentApplication.Interfaces_Service
{
    public interface IVisitorService
    {
        Task<IEnumerable<VisitorDto>> GetAllAsync();

        Task<VisitorDto?> GetByIdAsync(int id);

        Task<VisitorDto> CreateAsync(CreateVisitorDto dto);

        Task<bool> UpdateAsync(int id, UpdateVisitorDto dto);

        Task<bool> DeleteAsync(int id);
    }
}